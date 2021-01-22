    public class WriteToConsoleOperation : IOperation<int>
    {
        public IEnumerable<int> Execute(IEnumerable<int> ints)
        {
            foreach (var i in ints)
            {
                Console.WriteLine(i);
                yield return i;
            }
         }
    }
