        public NewForm()
        {
            InitializeComponent();
            SetVisibleCore(false);
        }
        private bool setCore = false;
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(setCore ? value : setCore);
        }
