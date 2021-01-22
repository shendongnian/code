    public namespace P
    {
        public interface IFoo {}
        public class RealFoo : IFoo { public int X; }
        public class OtherFoo : IFoo { public double X; }
        public class Flibble
        {
            public XmlAnything<IFoo> Foo;
        }
    
        public static void Main(string[] args)
        {
            var x = new Flibble();
            x.Foo = new XmlAnything<IFoo>(new RealFoo());
            var s = new XmlSerializer(typeof(Flibble));
            var sw = new StringWriter();
            s.Serialize(sw, x);
            Console.WriteLine(sw);
        }
    }
