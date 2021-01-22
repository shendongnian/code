    class StackOverflowParalell
    {
        public void Execute()
        {
            List<int> codeParam = new List<int>(){1,2,3};
            ConcurrentBag<string> result = new ConcurrentBag<string>();
            Parallel.For(0, codeParam.Count, i => DoSometing(i).ForEach( result.Add ));
            // return result here as List, Array....
        }
        List<string> DoSometing(int value)
        {
            return new List<string>(){"1","2","3","4"};
        }
    }
