    public void DoWork(Parent obj)
    {
       if(obj is A)
         Foo((A)obj);
       else if(obj is B)
         Foo((B)obj);
       else
        Foo(obj);
    }
    public void Foo(Parent obj)
    {
      //Do something for parent
    }
    public void Foo(A obj)
    {
      //Do something for A
    }
    public void Foo(B obj)
    {
      //Do something for B
    }
