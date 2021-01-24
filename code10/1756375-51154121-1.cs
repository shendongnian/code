    public class Visitor
    {
        Writer writerFactory = new WriterFactory();
        public void Visit(A a) => writerFactory.Create<A>().Write(a);
        public void Visit(B b) => writerFactory.Create<B>().Write(b);
    }
