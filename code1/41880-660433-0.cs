    class Foo {
       private Bar bar;
       public Foo(Bar bar) {
           this.bar = bar;
       }
       public event EventHandler SomeEvent {
           add {bar.SomeEvent += value;}
           remove {bar.SomeEvent -= value;}
       }
       //...
    }
