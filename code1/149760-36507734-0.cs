    public class A
    {
        public A()
        {
            var rnd=new Random();
            ID=rnd.Next();
        }
        public int ID { get; private set; }
    }
    public class B
    {
        public B()
        {
            var rnd=new Random();
            ID=rnd.Next();
        }
        public int ID { get; private set; }
    }
