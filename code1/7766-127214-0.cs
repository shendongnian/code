    public abstract class ToolStripItemCommand
    {
        private bool enabled = true;
        private bool visible = true;
        private readonly List<ToolStripItem> controls;
    
        protected ToolStripItemCommand()
        {
            controls = new List<ToolStripItem>();
        }
    
        public void RegisterControl(ToolStripItem item, string eventName)
        {
            item.Click += delegate { Execute(); };
            controls.Add(item);
        }
    
        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                foreach (ToolStripItem item in controls)
                    item.Enabled = value;
            }
        }
    
        public bool Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                foreach (ToolStripItem item in controls)
                    item.Visible = value;
            }
        }
    
        protected abstract void Execute();
    }
