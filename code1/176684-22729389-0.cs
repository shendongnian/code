    class Program
    {
        static bool SomeCondition = false;
        static bool SomeOtherNestedCondition = false;
        static void Main(string[] args)
        {    
            for (int i = 0; i < 2; i++)
            {
                if (SomeCondition)
                {
                    //do some things
                    if (SomeOtherNestedCondition)
                    {
                        //do some further things
                    }
                }
                Console.WriteLine("This text appeared from the first loop.");
            }
            for (int i = 0; i < 2; i++)
            {
                if (!SomeCondition) continue;
                //do some things
                if (!SomeOtherNestedCondition) continue;
                //do some further things
                Console.WriteLine("This text appeared from the second loop.");
            }
            Console.ReadLine(); 
        }
    }
