    public OptionsForm()
        {
            InitializeComponent();
            AlternativerRoot = Alternativer.GetReadOnlyRoot(AlternativerFanerNameValueList.GetNameValueList(Settings.Default.AlternativerFaner));
            InitUI();
            Closing += MyFormClosing;
            _bindingSourceTree = BindingSourceHelper.InitializeBindingSourceTree(components, rootBindingSource);
        }
