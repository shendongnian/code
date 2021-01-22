    class FooBar : IEnumerator
    {
      private List<Foo> list;
    
      public IEnumarator GetEnumerator()
      {
        return list.GetEnumerator();
      }
      public void SetList(List list)
      {
        this.list = list; // you can also make this more general and convert the parameter so it fits your listimpl.
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
