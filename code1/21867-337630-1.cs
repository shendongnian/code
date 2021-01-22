    public class MoodyObject
    {
        protected virtual String getMood()
        {
            return "moody";
        }
        public void queryMood()
        {
            Console.WriteLine("I feel " + getMood() + " today!");
        }
    }
    public class SadObject : MoodyObject
    {
        protected override String getMood()
        {
            return "sad";
        }
        //specialization
        public void cry()
        {
            Console.WriteLine("wah...boohoo");
        }
    }
    public class HappyObject : MoodyObject
    {
        protected override String getMood()
        {
            return "happy";
        }
        public void laugh()
        {
            Console.WriteLine("hehehehehehe.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MoodyObject moodyObject = new MoodyObject();
            SadObject sadObject = new SadObject();
            HappyObject happyObject = new HappyObject();
            Console.WriteLine("How does the moody object feel today?");
            moodyObject.queryMood();
            Console.WriteLine("");
            Console.WriteLine("How does the sad object feel today?");
            sadObject.queryMood();
            sadObject.cry();
            Console.WriteLine("");
            Console.WriteLine("How does the happy object feel today?");
            happyObject.queryMood();
            happyObject.laugh();
            Console.Read();
        }
    }
