    class Foo: IFoo
    {
      Foo(int gottaHaveThis) {};
      static Bar() {};
    }
    
    class SonOfFoo: Foo 
    {
      // SonOfFoo(int gottaHaveThis): base(gottaHaveThis); is implicitly defined
    }
    
    class DaughterOfFoo: Foo
    {
      DaughhterOfFoo (int gottaHaveThis) {};
    }
