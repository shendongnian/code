    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyService : IAllOfMyOps
    {
        public string OpA()
        {
            return "A";
        }
        public string OpB()
        {
            return "B";
        }
    }
