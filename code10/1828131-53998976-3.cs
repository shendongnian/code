    public Settings_form: MyDerivedForm
    {
        public Settings_form()
        {
            InitializeComponent();
        }
        private void UseDarkMode_chk_CheckedChanged(object sender, EventArgs e)
        {
            //Some code
            SettingsClass.UseDarkMode = this.UseDarkMode_chk.Checked;
        
            foreach(MyDerivedForm form in Application.OpenForms.OfType<MyDerivedForm>())
            {
                form.ChangeTheme(SettingsClass.UseDarkMode);
            }
        }
    }
