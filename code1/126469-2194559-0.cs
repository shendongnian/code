    public class MyClass {
        private List<T> myList;public class MyClass
        private ReadOnlyCollection<T> myReadOnlyList;
        public MyClass() { 
            myList = new List<T>();
            myReadOnlyList = myList.AsReadOnly;
    }
