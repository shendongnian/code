    public new Foo this[int index]
    {
       get
       {
          IList<Foo> self = this;
          return self[index];
       }
       set
       {
           (IList<Foo>)[index] = value;
       }
    }
