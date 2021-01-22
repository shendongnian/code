    public class CBase
        {
            static Talkative m_Baseob1 = new Talkative("Base Static Initializer-");
            static Talkative m_Baseob2;
            Talkative m_Baseob3 = new Talkative("Base Inst Initializer");
            Talkative m_Baseob4;
            static CBase()
            {
                Console.WriteLine("***MethodBegin: Static Base Ctor");
                m_Baseob2 = new Talkative("Base Static Ctor");
                Console.WriteLine("***MethodEnd: Static Base Ctor");
            }
            public CBase()
            {
                Console.WriteLine("***MethodBegin: Instance Base Ctor");
                m_Baseob4 = new Talkative("Base Instance Ctor");
                Console.WriteLine("***MethodEnd: Instance Base Ctor");
            }
        }
        public class CDerived : CBase
        {
            static Talkative m_ob1 = new Talkative("Derived Static Initializer");
            static Talkative m_ob2;
            Talkative m_ob3 = new Talkative("Derived Inst Initializer");
            Talkative m_ob4;
            static CDerived()
            {
                Console.WriteLine("***MethodBegin: Derived Static Ctor");
                m_ob2 = new Talkative("Derived Static Ctor");
                Console.WriteLine("***MethodEnd: Derived Static Ctor");
            }
            public CDerived()
            {
                Console.WriteLine("***MethodBegin: Derived Instance Ctor");
                m_ob4 = new Talkative("Derived Instance Ctor");
                Console.WriteLine("***MethodEnd: Derived Instance Ctor");
            }
        }
        internal class Talkative
        {
            public Talkative(string sID)
            {
                Console.WriteLine(sID + " - Talkative created" );
            }
        }
     
        # Main function somewhere
        CDerived s = new CDerived();
