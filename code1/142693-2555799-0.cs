    public class MyClass<T> where T : IComparable<T> { 
        public T MaxValue  { 
            // Implimentation for MaxValue 
        } 
     
        public T MyMethod(T argument) { 
            if(argument.CompareTo(this.MaxValue) > 0){ 
                 // Then do something 
            } 
        } 
    }
