    public class AnotherObject 
    { 
        public AnotherObject<T>(T someObject) where T : BaseClass
        { 
            someObject.MyMethod(); //This calls the BaseClass method, unfortunately. 
        } 
    } 
