    class Foo<T> : SomeBaseClass
    {
        public override MyFunction(object value)
        {
           if(value.GetType() != typeof(T))
           {
              // wrong type throw exception or similar
           }
        }
    }  
 
 
