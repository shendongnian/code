    namespace N1
    {
       internal class ClassB  
       {
         private ClassA _classAInstance;
         
         public void ClassB(ClassA classAInstance)
         {
             _classAInstance = classAInstance;
         }
         private void method()
         {
           // You can access _classAInstance properties here
         }
       }
    }
