    public class MyClass
    {
        // ...
        static MyClass()
        {
            myList = new List<MyClass>();
            myList.Add(new MyClass());
            // ...
        }
        private static List<MyClass> myList = null;
        public static List<MyClass> MyList
        {
            get { return myList; }
        }
    }
