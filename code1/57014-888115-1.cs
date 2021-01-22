    class FooBar : IEnumerator
    {
      private Collection<Foo> col;
    
      public IEnumarator GetEnumerator()
      {
        return col.GetEnumerator();
      }
      public void SetList(Collection col)
      {
        this.col= col; // you can also make this more general and convert the parameter so it fits your listimpl.
      }
    }
    
    class Clazz
    {
      private void WhatEver(){
        FooBar foobar = new FooBar();
        ...
        foreach(Foo f in foobar)
        {...}
      }
    }
