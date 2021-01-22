    static void Main()
    {
        ISomeInterface si = new EvilClass();
        si.DoSomething(); // mwahahah
    }
    public class EvilClass : ASomeAbstractImpl, ISomeInterface
    {
        public override void A() {}
        public override void B() { }
        void ISomeInterface.DoSomething()
        {
            Console.WriteLine("mwahahah");            
        }
    }
