    //My base class
    //I add a type to my base class use that in the static method to check the type of the caller.
    public class Parent<TSelfReferenceType>
    {
        public static Type GetType()
        {
            return typeof(TSelfReferenceType);
        }
    }
