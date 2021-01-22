    public struct Foo {
    
       public Foo(int bar, int baz) {
          _bar = bar;
          _baz = baz;
       }
    
       private int _bar, _baz;
    
       public int Bar { get { return _bar; } }
       public int Baz { get { return _baz; } }
    
    }
