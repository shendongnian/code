    interface I
    {
       void Method();
    }
    class B : I
    {
       public void Method() { /* previously A.Method(B) */}
    }
    class C : I
    {
       public void Method() { /* previously A.Method(C) */ }
    }
    class A
    {
       public void Method(I obj)
       { 
         obj.Method();
       }
    }
