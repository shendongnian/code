    public class Base {
        public int Data;
     
        public void DoStuff() {
            // Do stuff with data
        }
    }
    
    public class Derived : Base {
        public int OtherData;
    
        public Derived(Base b) {
            this.Data = b.Data;
            OtherData = 0; // default value
        }
    
        public void DoOtherStuff() {
            // Do some other stuff
        }
    }
 
