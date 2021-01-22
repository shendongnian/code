    public class MyClass
    {
        // ...
        private static List<MyClass> myList = null;
        public static List<MyClass> MyList
        {
            get {
                if (myList == null) {
                   myList = new List<MyClass>();
                   myList.Add(new MyClass());
                   // ...
                }
                return myList;
            }
        }
    }
