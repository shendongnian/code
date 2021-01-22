    using System;
    
    public class MyBusinessObjectClass
    {
        public string MyProperty { get; private set; }
    
        private MyBusinessObjectClass(string myProperty)
        {
            MyProperty = myProperty;
        }
    
        // Need accesible default constructor, or else MyBusinessObjectFactory declaration will generate:
        // error CS0122: 'MyBusinessObjectClass.MyBusinessObjectClass(string)' is inaccessible due to its protection level
        protected MyBusinessObjectClass()
        {
        }
    
        protected static MyBusinessObjectClass Construct(string myProperty)
        {
            return new MyBusinessObjectClass(myProperty);
        }
    }
    
    public abstract class MyBusinessObjectFactory : MyBusinessObjectClass
    {
        public static MyBusinessObjectClass CreateBusinessObject(string myProperty)
        {
            // Perform some check on myProperty
    
            if (true /* check is okay */)
                return Construct(myProperty);
    
            return null;
        }
        private MyBusinessObjectFactory()
        {
        }
    }
