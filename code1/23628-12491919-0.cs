    public partial class RegistryManager : Component, ISupportInitialize
    {
        private Form _parentForm;
        public Form ParentForm
        {
            get { return _parentForm;  }
            set { _parentForm = value; }
        }
............
        #region ISupportInitialize
        public void BeginInit() {  }
        public void EndInit()
        {
            setUpParentForm();
        }
        private void setUpParentForm()
        {
            if (_parentForm != null) return; // do nothing if it is set
            IDesignerHost host;
            if (Site != null)
            {
                host = Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (host != null)
                {
                    if (host.RootComponent is Form)
                    {
                        _parentForm = (Form)host.RootComponent;
                    }
                }
            }
        }
        #endregion
    }
