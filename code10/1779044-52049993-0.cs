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
        public override ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                if (selectionService != null)
                {
                    selectionService.SelectionChanging -= OnSelectionChanging;
                }
                base.Site = value;
                if (value != null)
                {
                    selectionService = (ISelectionService)this.Site.GetService(typeof(ISelectionService));
                    if (selectionService != null)
                    {
                        selectionService.SelectionChanging += OnSelectionChanging;
                    }
                }
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
