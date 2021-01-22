    class Parent
    {
        public void AddUser()
        {
          // pre-logic here
          AddUserCore();
          // post-logic here
        }
    
        protected abstract void AddUserCore();
    }
    
    // child class 
    class Child : Parent
    {
       protected override void AddUserCore()
       { 
         // child addUser code  
       }
    }
