    public static class DemoClass
    {
        private static readonly ConcurrentBag<object> ListTrue = new ConcurrentBag<object>();
        private static readonly ConcurrentBag<int> ListFalse = new ConcurrentBag<int>();
    
        static void Main(string[] args)
        {
            var sequence = Enumerable.Range(1, 10).ToList(); //Prepare a sequence from 1 to 10
    
            sequence
                .AsParallel()
                .ForAll(i => //i will take the value of each element of the sequence
                {
                    //If your function returns true nothing happend here, the element where
                    //added in "myFunction", if the method returned false, then just save
                    //the value so you can check the results outside this parallel for
                    if (!myFunction(i, ListTrue))
                        ListFalse.Add(i);
                });
    
            System.Console.WriteLine(
                $@"{ListFalse.Count} elements resulted false, {ListTrue.Count} where true"
            );
        }
    
        private static bool myFunction(int number, ConcurrentBag<object> list)
        {
            // My code (it takes around 2 minutes here), it could return false here
    
            list.Add(new object());
            return true;
        }
    }
