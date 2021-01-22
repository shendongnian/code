    abstract class Customer {
        protected CustomerEdit customerEdit; // customers have an object which allows for edit
    
        public virtual string Name { get; set; }
        public void Display() { customerEdit.Display(); } // allow the CustomerEdit implementor to display the UI elements
    }
    
    // Set customerEdit in constructor, tie with "this"
    class HighValueCustomer : Customer {
        public virtual int MaxSpending { get; set; }
    } 
    
    // Set customerEdit in constructor, tie with "this"
    class SpecialCustomer : Customer {
        public virtual string Award { get; set; }
    }
