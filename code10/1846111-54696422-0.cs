        public Form1()
        {
            InitializeComponent();
            lst_BarcodeScanEvents.ControlAdded += new ControlEventHandler(AddedNewSelect);
        }
        
        private void AddedNewSelect(object sender, ControlEventArgs e)
        {
            lst_BarcodeScanEvents.SetItemChecked(e.Control.TabIndex, true);
        }
