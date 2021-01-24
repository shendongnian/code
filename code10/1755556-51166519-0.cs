    class HeavyClass
    {
        MD5 _md5 = MD5.Create();
        MethodInfo _hashCoreMI = _md5.GetType().GetMethod("HashCore", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo _HashFinalMI = _md5.GetType().GetMethod("HashFinal", BindingFlags.NonPublic | BindingFlags.Instance);
        WaitHandle _signal;
     
        public void HeavyClass(WaitHandle signal)
        {
            _signal = signal;
        }
        public string HeavyRun(string filename)
        {
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            _signal.Set();
            using(FileStream fs = File.OpenRead(filename))
            {
                while(true)
                {
                    bytesRead = fs.Read(buffer, 0, 4096);
                    if (bytesRead > 0)
                    {
                        _hashCoreMI.Invoke(_md5, new object[] { buffer, 0, bytesRead });
                    }
                    else
                    {
                        break;
                    }
                    
                    // if WaitHandle is signalled, thread will be block,
                    // otherwise thread will keep running.
                    _signal.WaitOne();
                }
            }
            byte[] hash = _hashFinalMI.Invoke(_md5, null);
            _md5.Initialize();
            return Encoding.ASCII.GetString(hash);;
        }
    }
    class MainWindow : Window
    {
        private HeavyClass _heavyClass;
        private ManualResetEvent _mre;
        public MainWindow()
        {
            InitializeComponent();
            _mre = new ManualResetEvent(true);
            _heavyClass = new HeavyClass(_mer);
        }
    
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(heavyClass.HeavyRun("D:\\Desktop\\bigfile.iso"));
            t.Start();
        }
    
        private void buttonPause_Click(object sender, RoutedEventArgs e)
        {
            _mre.Reset();
        }
        private void buttonResume_Click(object sender, RoutedEventArgs e)
        {
            _mre.Set();
        }
    }
