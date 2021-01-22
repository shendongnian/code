    public class BusinessLogic
    {
        public event EventHandler ProgressChanged;
        private int _Progress;
        public int Progress
        {
            get { return _Progress;  }
            private set
            {
                _Progress = value;
                EventHandler h = ProgressChanged;
                if (h != null)
                {
                    h(this, new EventArgs());
                }
            }
        }
    }
