    class Parent
    {
        // Public identifiers cannot be overridden in C#
        private string _val = "Parent";
        // Public properties can.
        public virtual string val
        {
            get { return _val; }
        }
    
        public void getValue()
        {
            Console.WriteLine(this.val);
        }
    }
    
    class Child : Parent
    {
        private string _val = "Child";
        public virtual string val
        {
            get { return _val; }
        }
    }
