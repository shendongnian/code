    public abstract class Foo {
        public void virtual Bar() {
            // default implementation
        }
    }
    
    public class NormalFoo : Foo { }
    
    public class SpecialFoo : Foo {
        public override void Bar() {
            // special implementation
        }
    }
    
    var foolist = new List<Foo>();
    
    foolist.Add( new NormalFoo() );
    foolist.Add( new SpecialFoo() );
    
    foreach (var f in foolist) {
        f.Bar();
    }
