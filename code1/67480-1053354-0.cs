    class Parent
    {
        public virtual string val = "Parent";
    
        public void getValue()
        {
            Console.WriteLine(this.val);
        }
    }
    
    class Child:Parent
    {
        public overrides string val = "Child";
    }
    
    Child child = new Child();
    child.getValue();
