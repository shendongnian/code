     class A {
      protected void Test3(){} //available to subclasses of A in any assembly
      protected internal void Test() { } //Same as protected :(
      public void Test2(){}//available to everyone
      internal void Test4(){} //available to any class in A's assembly 
     }
    
     class B : A {
      void TestA() {
       Test(); //OK
      }
     }
     //Different assembly
     class C : B {
      void TestA() {
       Test4(); //error CS0103: The name 'Test4' does not exist in the current context
      }
     }
