    class Parent{    
        public virtual string val 
        {
            get { return "Parent"; }
        }
        
        public void getValue()    
        {        
            Console.WriteLine(this.val);    
        }
    }
    
    class Child:Parent
    {
        public override string val
        {
            get { return "Child"; }
        }
    }
