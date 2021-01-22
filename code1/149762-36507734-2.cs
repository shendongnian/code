    public static class Utils
    {
        public static readonly Random random=new Random();
    }
    public class A
    {
        public A()
        {
            ID=Utils.random.Next();
        }
        public int ID { get; private set; }
    }
    public class B
    {
        public B()
        {
            ID=Utils.random.Next();
        }
        public int ID { get; private set; }
    }
