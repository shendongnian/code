    abstract class Maker {
       public abstract int SomeProperty { get; }
    }
    
    abstract class MakerFactory {
       public abstract Maker GetMaker();
    }
    class Nail:Maker {
    }
    
    class ConcreteNailFactory:NailFactory {
       public override Maker GetMaker() {
          return new Nail();
       }
    }
