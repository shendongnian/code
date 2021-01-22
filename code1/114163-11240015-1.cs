    namespace ExplConsole
    {
        class Program 
        {
            static void Main ()
            {
                System.Console.WriteLine("Permission for User1");
                User1 usr1 = new Test(); // Create instance.
                usr1.Read(); // Call method on interface.
                usr1.Write();
                System.Console.WriteLine("Permission for User2");
                User2 usr2 = new Test();
                usr2.Write();
                usr2.Execute();
                System.Console.ReadKey();
            }
        }
        interface User1
        {
            void Read();
            void Write();
        }
        interface User2
        {
            void Write();
            void Execute();
        }
        class Test : NewTest,User1, User2 
        {
            public void Read()
            {
                Console.WriteLine("Read");
            }
            public void Write()
            {
                Console.WriteLine("Write");
            }
        }
        class NewTest 
        {
            public void Execute()
            {
                Console.WriteLine("Execute");
            }
        }
    }
