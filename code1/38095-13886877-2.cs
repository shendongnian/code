    public class BaseThings
    {
        protected static void AssertPermissions()
        {
            //something
        }
    }
    
    public class Person:BaseThings
    {
        public static void ValidatePerson(Person person)
        {
            //just call the base static method as if it were in this class.
            AssertPermissions();            
        }
    }
