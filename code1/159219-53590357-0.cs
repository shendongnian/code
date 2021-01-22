    class Program
    {
        static void Main(string[] args)
        {
            DoSomething l_Class = new DoSomething();
            Console.WriteLine("Seed: {0}", l_Class.Seed);
            Console.WriteLine("Saving State");
            DoSomething.SomeState l_State = l_Class.Save_State();
            l_Class.Regen_Seed();
            Console.WriteLine("Regenerated Seed: {0}", l_Class.Seed);
            Console.WriteLine("Restoring State");
            l_Class.Restore_State(l_State);
            Console.WriteLine("Restored Seed: {0}", l_Class.Seed);
            Console.ReadKey();
        }
    }
    class DoSomething
    {
        static Func<DoSomething, SomeState> g_SomeState_Ctor;
        static DoSomething()
        {
            Type type = typeof(SomeState);
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(type.TypeHandle);
        }
        Random c_Rand = new Random();
        public DoSomething()
        {
            Seed = c_Rand.Next();
        }
        public SomeState Save_State()
        {
            return g_SomeState_Ctor(this);
        }
        public void Restore_State(SomeState f_State)
        {
            ((ISomeState)f_State).Restore_State(this);
        }
        public void Regen_Seed()
        {
            Seed = c_Rand.Next();
        }
        public int Seed { get; private set; }
        public class SomeState : ISomeState
        {
            static SomeState()
            {
                g_SomeState_Ctor = (DoSomething f_Source) => { return new SomeState(f_Source); };
            }
            private SomeState(DoSomething f_Source) { Seed = f_Source.Seed; }
            void ISomeState.Restore_State(DoSomething f_Source)
            {
                f_Source.Seed = Seed;
            }
            int Seed { get; set; }
        }
        private interface ISomeState
        {
            void Restore_State(DoSomething f_Source);
        }
    }
