    class Test
        {
            static void Main()
            {
                List<Action> word = new List<Action>();
                word.Add(new GroupOne().ExpressWords());
                word.Add(new GroupTwo().ExpressWords());
    
                foreach (Action del in word)
                {
                      del();
                }
               Console.ReadKey(true);
            }
        }
