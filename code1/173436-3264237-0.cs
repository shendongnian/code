    abstract class Main
    {
        public int number{get; private set;}
        
        public void dostuff(){
            int x = number;
        }
    }
    
    class Derived:Main
    {
        public Derived()
        {
            number = 5; // Specific value for each derived class
        }
        public void dostuff(){
            int x = number;
        }
    }
