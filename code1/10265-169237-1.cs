    public class foo {
      private foo(){
        Bar = "bar";
      }
      public foo(int something) : foo(){
        //do normal constructor stuff
      }
      public string Bar {get;set;}
    }
