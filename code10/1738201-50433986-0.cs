    public class MyClass<T> where T : IComparable<T>
    {
        public void MyMethod(T a, T b) 
        {
           //some code
           var result = a.CompareTo(b) < 0; // a < b
           //some code 
        }
    }
