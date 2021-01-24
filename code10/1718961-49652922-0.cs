    class Base {
        public string name = ""; 
        public Base() { name = "X"};
        
    }
    
    class Derived : Base {
        public Derived() { name = "Y"}; //same {name } field of a Base class
    }
