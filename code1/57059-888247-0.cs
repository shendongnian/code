    class BaseClass
    {
         public String IWantThis { get; set; }
         public String IDoNotWantThis { get; set; }
    }
    class MyClass
    {
        private BaseClass baseClass = new BaseClass();
        public String IWantThis
        {
            get { return this.baseClass.IWantThis; }
            set { this.baseClass.IWantThis = value; }
        }
    }
