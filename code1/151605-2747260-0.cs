    class Program
        {
            static void Main(string[] args)
            {
                SubSub obj = new SubSub();                
                //obj.DoStuff();
                Console.ReadLine();
            }
        }
    
        class Super
        {
            public Super()
            {
                Console.WriteLine("Constructing Super");
            }
            public void DoStuff()
            {
                Console.WriteLine("Doin' stuff");
            }
        }
    
        class Sub : Super
        {
            public Sub()
            {
                Console.WriteLine("Constructing Sub");
            }
        }
    
        class SubSub : Sub
        {
            public SubSub()
            {
                Console.WriteLine("Constructing SubSub");
                DoStuff();
            }
        }
