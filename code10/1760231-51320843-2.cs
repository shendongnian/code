       public class MyClass {
         ...
         public bool IsEmpty {
           get {
             return string.IsNullOrWhiteSpace(FirstName) &&
                    string.IsNullOrWhiteSpace(SecondName) &&
                    ...
           }
         } 
       }
