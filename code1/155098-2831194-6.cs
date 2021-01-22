    interface IPressable {
      void Press();
    }
    
    class Foo {
     void Bar(IPressable pressable) {
        pressable.Press();
     }
    }
    
    class Thingy : IPressable, IPushable, etc {
     public void Press() {
     }
    }
    
    static class Program {
     public static void Main() {
      pressable = new Thingy();
      new Foo().Bar(pressable);
     }
    }
