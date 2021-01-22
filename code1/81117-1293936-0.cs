    static class Global
    {
        private string _globalVar = "";
        public static string GlobalVar
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }
    }
