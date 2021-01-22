    class MyMenuItem : MenuItem
    {
        public string[] Info { get; private set; }
    
        public MyMenuItem(string[] strInfo)
        {
            this.Info = strInfo;
        }
    }
