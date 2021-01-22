    interface IM1{
         int Method1(int number1);
    }
    
    interface IM2{
         int Method2(int number2);
    }
    
    class Class1 : IM1{
         int Method1(int number1){
              // Implement your logic
         }
    }
    
    class Class2 : IM2{
         int Method2(int number2){
              // Implement your logic
         }
    }
    
    // Client Code
        public void SomeFunction(IM2 x){
             x. Method2(1); // This will work as this is the only thing this client wants.
        }
