    class Program
    {
        static void Main(string[] args)
        {
            var scanner = new TwainScanner();
            scanner.Scan("your device id");
            Console.ReadLine();
        }
    }
    public sealed class CustomTwainSession : TwainSession
    {
        private Exception _error;
        private bool _cancel;
        private ReturnCode _returnCode;
        private DataSource _dataSource;
        private Bitmap _image;
        public Exception Error => _error;
        public bool IsSuccess => _error == null && _returnCode == ReturnCode.Success;
        public Bitmap Bitmap => _image;
        static CustomTwainSession()
        {
            PlatformInfo.Current.PreferNewDSM = false;
        }
        public CustomTwainSession(): base(TwainScanner.TwainAppId)
        {
            _cancel = false;
            TransferReady += OnTransferReady;
            DataTransferred += OnDataTransferred;
            TransferError += OnTransferError;
        }
        public void Start(string deviceId)
        {
            try
            {
                _returnCode = Open();
                if (_returnCode == ReturnCode.Success)
                {
                    _dataSource = this.FirstOrDefault(x => x.Name == deviceId);
                    if (_dataSource != null)
                    {
                        _returnCode = _dataSource.Open();
                        if (_returnCode == ReturnCode.Success)
                        {
                            _returnCode = _dataSource.Enable(SourceEnableMode.NoUI, false, IntPtr.Zero);
                        }
                    }
                    else
                    {
                        throw new Exception($"Device {deviceId} not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                _error = ex;
            }
            if (_dataSource != null && IsSourceOpen)
            {
                _dataSource.Close();
            }
            if (IsDsmOpen)
            {
                Close();
            }
        }
        private void OnTransferReady(object sender, TransferReadyEventArgs e)
        {
            _dataSource.Capabilities.CapFeederEnabled.SetValue(BoolType.False);
            _dataSource.Capabilities.CapDuplexEnabled.SetValue(BoolType.False);
            _dataSource.Capabilities.ICapPixelType.SetValue(PixelType.RGB);
            _dataSource.Capabilities.ICapUnits.SetValue(Unit.Inches);
            TWImageLayout imageLayout;
            _dataSource.DGImage.ImageLayout.Get(out imageLayout);
            imageLayout.Frame = new TWFrame
            {
                Left = 0,
                Right = 210 * 0.393701f,
                Top = 0,
                Bottom = 297 * 0.393701f
            };
            _dataSource.DGImage.ImageLayout.Set(imageLayout);
            _dataSource.Capabilities.ICapXResolution.SetValue(150);
            _dataSource.Capabilities.ICapYResolution.SetValue(150);
            if (_cancel)
            {
                e.CancelAll = true;
            }
        }
        private void OnDataTransferred(object sender, DataTransferredEventArgs e)
        {
            using (var output = Image.FromStream(e.GetNativeImageStream()))
            {
                _image = new Bitmap(output);
            }
        }
        private void OnTransferError(object sender, TransferErrorEventArgs e)
        {
            _error = e.Exception;
            _cancel = true;
        }
        public void Dispose()
        {
            _image.Dispose();
        }
    }
    public sealed class TwainScanner
    {
        public static TWIdentity TwainAppId { get; }
        private static CustomTwainSession Session { get; set; }
        static volatile object _locker = new object();
        static TwainScanner()
        {
            TwainAppId = TWIdentity.CreateFromAssembly(DataGroups.Image | DataGroups.Control, Assembly.GetEntryAssembly());
        }
        public Bitmap Scan(string deviceId)
        {
            bool lockWasTaken = false;
            try
            {
                if (Monitor.TryEnter(_locker))
                {
                    lockWasTaken = true;
                    if (Session != null)
                    {
                        Session.Dispose();
                        Session = null;
                    }
                    Session = new CustomTwainSession();
                    Session.Start(deviceId);
                    return Session.Bitmap;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                if (lockWasTaken)
                {
                    Monitor.Exit(_locker);
                }
            }
        }
    }
