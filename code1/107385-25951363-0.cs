    class Program
        {
            static void Main(string[] args)
            {
                Parent p = new Parent();
            }
        }
    
    	////////////////////////////////////////////
    	
        public delegate void DelegateName(string data);
         
        class Child
        {
            public event DelegateName delegateName;
            
            public void call()
            {
                delegateName("Narottam");
            }
        }
    	
    	///////////////////////////////////////////
    	
    	class Parent
        {
            public Parent()
            {
                Child c = new Child();
                c.delegateName += new DelegateName(print);
    			//or like this
    			//c.delegateName += print;
                c.call();
            }
    
            public void print(string name)
            {
                Console.WriteLine("yes we got the name : " + name);
            }
        }
