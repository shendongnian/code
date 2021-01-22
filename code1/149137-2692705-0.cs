    public class DataChangedEventArgs : EventArgs
    {
        public string Data { get; set; }
        public DataChangedEventArgs(string data)
        {
            Data = data;
        }
    }
    public delegate void DataChangedEventHander(DataChangedEventArgs e);
    public class BackEnd
    {
        public event DataChangedEventHander OnDataChanged;
        private string _data;
        public string Data
        {
            get { return _data; }
            set
            {
                _data = value;
                RaiseOnDataChanged();
            }
        }
        private static readonly object _sync = new object();
        private static BackEnd _instance;
        public static BackEnd Current
        {
            get
            {
                lock (_sync)
                {
                    if (_instance == null)
                        _instance = new BackEnd();
                    return _instance;
                }
            }
        }
        private void RaiseOnDataChanged()
        {
            if(OnDataChanged != null)
                OnDataChanged(new DataChangedEventArgs(Data));
        }
    }
    public class ConsumerControl
    {
        public event EventHandler OnTextChanged;
        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                if (OnTextChanged != null)
                    OnTextChanged(this, EventArgs.Empty);
            }
        }
    }
    public class Consumer
    {
        public ConsumerControl Control { get; set; }
        public Consumer()
        {
            Control = new ConsumerControl();
            BackEnd.Current.OnDataChanged += NotifyConsumer;
            Control.OnTextChanged += OnTextBoxDataChanged;
        }
        private void OnTextBoxDataChanged(object sender, EventArgs e)
        {
            NotifyBackEnd();
        }
        private void NotifyConsumer(DataChangedEventArgs e)
        {
            Control.Text = e.Data;
        }
        private void NotifyBackEnd()
        {
            // unsubscribe
            BackEnd.Current.OnDataChanged -= NotifyConsumer;
            BackEnd.Current.Data = Control.Text;
            // subscribe again
            BackEnd.Current.OnDataChanged += NotifyConsumer;
        }
    }
    public class BackEndTest
    {
        public void Run()
        {
            var c1 = new Consumer();
            var c2 = new Consumer();
            c1.Control.Text = "1";
            BackEnd.Current.Data = "2";
        }
    }
