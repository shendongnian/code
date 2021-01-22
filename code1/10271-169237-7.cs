    public class foo {
      private foo(){
        Bar = "bar";
        Baz = "baz";
      }
      public foo(int something) : this(){
        //do specialized initialization here
        Baz = string.Format("{0}Baz", something);
      }
      public string Bar {get; set;}
      public string Baz {get; set;}
    }
