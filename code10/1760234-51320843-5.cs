       public class MyClass {
         ...
         // virtual: you may want to add some properties in a derived class 
         public virtual bool IsEmpty {
           get {
             return string.IsNullOrWhiteSpace(FirstName) &&
                    string.IsNullOrWhiteSpace(SecondName) &&
                    ...
           }
         } 
       }
