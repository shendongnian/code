    public interface IInnerClass {
    }
    
    public class OuterClass {
       public IInnerClass foo {get; private set;}
       public OuterClass() {
          foo = new InnerClass();
       }
       private class InnerClass : IInnerClass {
          sometype somevar;
          public InnerClass(){}
       }
    }
