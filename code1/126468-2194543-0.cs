    public class MyClass 
    { 
        private List<T> myList = new List<T>(); 
        private ReadOnlyCollection<T> myReadOnlyList;
        public MyClass()
        {
            myReadOnlyList = myList.AsReadOnly; 
        }
 
    } 
