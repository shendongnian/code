    public class NamedBackgroundWorker : BackgroundWorker
    {
        public NamedBackgroundWorker(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            Thread.CurrentThread.Name = Name;
            base.OnDoWork(e);
        }
    }
