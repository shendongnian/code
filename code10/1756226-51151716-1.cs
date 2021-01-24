    public class OuterClass {
       public InnerClass foo {get; private set}
       public OuterClass() {
          foo = new InnerClass()
       }
       public class InnerClass {
          protected sometype somevar;
          protected InnerClass()
       }
    }
