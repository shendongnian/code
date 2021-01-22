    Class test<T>
    {
         T method1(object Parameter1){
             if( Parameter1 is T ) 
             {
                  T value = (T) Parameter1;
                 //do something with value
                 return value;
             }
             else
             {
                 //Parameter1 is not a T
                 return default(T); //or throw exception
             }
         }
    }
