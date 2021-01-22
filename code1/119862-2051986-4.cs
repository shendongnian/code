    public static class GlobalForms
    {
        private MainForm _main;
        public MainForm Main
        {
            get
            {
                if (_main == null) _main = new MainForm();
                return _mainForm;
            }
        }
        
    }
