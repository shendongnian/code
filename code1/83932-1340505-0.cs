     class Program
        {
            static void Main(string[] args)
            {
                Predicate<int> when = i => i > 100 && Console.ReadKey().KeyChar.ToString() == "0";
    
                foreach(var i in Numbers().BreakOn(when))
                {
                    Console.WriteLine(i);
                }
                
                Console.ReadLine();
            }
    
            private static IEnumerable<int> Numbers()
            {
                var i = 0;
                while(true)
                {
                    yield return i++;
                }
            }
    
            
        }
    
        public static class Util
        {
            public static IEnumerable<int> BreakOn(this IEnumerable<int> sequence, Predicate<int> when)
            {
                foreach(int i in sequence)
                {
                    if(when(i))
                    {
                        yield break;
                    }
                    yield return i;
                }
            }
    }
