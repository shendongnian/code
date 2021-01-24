    [DesignerAttribute(typeof(MyControlDesigner))]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ucInput : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel InternalPanel
        {
            get { return pnlContent; }
        }
        public ucInput()
        {
            InitializeComponent();
        }
        private ISelectionService selectionService;
        private IDesignerHost host;
        public override ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                host = null;
                UnSubscribeFromSelectionService();
                base.Site = value;
                if (value != null)
                {
                    host = (IDesignerHost)this.Site.GetService(typeof(IDesignerHost));
                    if (host != null)
                    {
                        if (host.Loading)
                        {
                            // defer subscription to selection service until fully loaded
                            host.Activated += Host_Activated;
                        }
                        else
                        {
                            SubscribeToSelectionService();
                        }
                    }
                }
            }
        }
        private void Host_Activated(object sender, EventArgs e)
        {
            host.Activated -= Host_Activated;
            SubscribeToSelectionService();
        }
        private void SubscribeToSelectionService()
        {
            selectionService = (ISelectionService)this.Site.GetService(typeof(ISelectionService));
            if (selectionService != null)
            {
                selectionService.SelectionChanging += OnSelectionChanging;
            }
        }
        private void UnSubscribeFromSelectionService()
        {
            if (selectionService != null)
            {
                selectionService.SelectionChanging -= OnSelectionChanging;
            }
        }
        private void OnSelectionChanging(object sender, EventArgs e)
        {
            if (selectionService.GetComponentSelected(pnlContent))
            {
                selectionService.SelectionChanging -= OnSelectionChanging;
                selectionService.SetSelectedComponents(new[] { pnlContent }, SelectionTypes.Remove);
                selectionService.SelectionChanging += OnSelectionChanging;
            }
        }
    }
