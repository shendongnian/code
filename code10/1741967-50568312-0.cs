    public class TestBrain
    {
        private static int NextId = 1;
        public TestBrain(List<MyTrigger> triggers)
        {
            this.Triggers = triggers;
            this.Id = NextId++;
        }
        public int Id { get; private set; }
        public int Hunger { get; set; }
        public int StomachFullness { get; set; }
        public List<MyTrigger> Triggers { get; private set; }
        public void FireTriggers()
        {
            foreach (MyTrigger t in this.Triggers)
            {
                t.Invoke(this);
                this.StomachFullness = 100;
            }
        }
        public delegate void MyTrigger(TestBrain b);
    }
    public class HumanBrain : TestBrain
    {
        static readonly List<MyTrigger> defaultHumanTriggers = new List<MyTrigger>()
        {
            b => { if (b.StomachFullness < 50) { b.Hunger = 1; Console.WriteLine("{0} is hungry..", b.Id); } }
        };
        public HumanBrain() : base(defaultHumanTriggers)
        {
        }
    }
    public class RobotBrain : TestBrain
    {
        static readonly List<MyTrigger> defaultRobotTriggers = new List<MyTrigger>()
        {
            b => { if (b.StomachFullness < 50) { Console.WriteLine("{0} ignores hunger only want's some oil..", b.Id); } }
        };
        public RobotBrain() : base(defaultRobotTriggers)
        {
        }
    }
    static void Main()
    {
        // Create some test-data
        List<TestBrain> brains = new List<TestBrain>()
        {
            new HumanBrain(),
            new HumanBrain(),
            new RobotBrain(),
            new HumanBrain(),
        };
        Console.WriteLine(" - - - Output our Testdata - - -");
        foreach (TestBrain b in brains)
        {
            Console.WriteLine("Status Brain {0} - Stomachfulness: {1} Hunger: {2}", b.Id, b.StomachFullness, b.Hunger);
        }
        Console.WriteLine(" - - - Empty stomachs - - -");
        foreach (TestBrain b in brains)
        {
            b.StomachFullness = 0;
        }
       
        Console.WriteLine(" - - - Fire triggers - - -");
        foreach (TestBrain b in brains)
        {
            b.FireTriggers();
        }
        Console.WriteLine(" - - - Output our Testdata - - -");
        foreach (TestBrain b in brains)
        {
            Console.WriteLine("Status Brain {0} - Stomachfulness: {1} Hunger: {2}", b.Id, b.StomachFullness, b.Hunger);
        }
    }
