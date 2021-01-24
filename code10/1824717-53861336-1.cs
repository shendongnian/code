    class A
    {
       public B _b {get; set;}
       public void OtherMethod();
    }
    
    class B
    {
       B(A a)
       {
          a._b = this;
       }
    }
