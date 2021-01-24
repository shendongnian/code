    public class Controller
    {
        // Fields, properties, methods and events go here...
        // note, this only works because its initializing a field 
        // its the same as initializing in a constructor
        Business instBusiness = new Business();
      
        // nope, not going to work
        // instBusiness
        public Controller()
        { 
           // yay!
           instBusiness.MyProperty = 5
        }
        public void SomeOtherMethod()
        { 
           // yayer!
           instBusiness.MyProperty = 5
        }
    }
