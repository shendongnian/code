    abstract class Properties
    {
        public abstract string Name { get; set; }
    }
    class MyClass
    {
        private class SubProperties : Properties
        {
            private MyClass myClass;
    
            public SubProperties(MyClass myClass)
            {
                this.myClass = myClass;
            }
    
            public override Name
            {
                get { return this.myClass.GetActualName(); }
                set { this.myClass.SetActualName(value); }
            }
        }
    
        private string name;
        public MyClass
        {
            this.MyClassProperties = new SubProperties(this);
        }
  
        public Properties MyClassProperties { get; private set; }
        private string GetActualName()
        {
            return this.name;
        }
    
        private void SetActualName(string s)
        {
            this.name = s;
        }
    }
