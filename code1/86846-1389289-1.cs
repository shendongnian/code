    public class MyTraceListener : TraceListener, INotifyPropertyChanged
    {
        private readonly StringBuilder builder;
        public MyTraceListener()
        {
            this.builder = new StringBuilder();
        }
        public string Trace
        {
            get { return this.builder.ToString(); }
        }
        public override void Write(string message)
        {
            this.builder.Append(message);
            this.OnPropertyChanged(new PropertyChangedEventArgs("Trace"));
        }
        public override void WriteLine(string message)
        {
            this.builder.AppendLine(message);
            this.OnPropertyChanged(new PropertyChangedEventArgs("Trace"));
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
