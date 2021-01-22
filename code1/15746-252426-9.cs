    class Program
    {
        public static void Main(string[] args)
        {
            //this could be your linq query
            var qry = TestSlowLoadingEnumerable();
            //We begin the call and give it our callback delegate
            //and a delegate to an error handler
            AsynchronousQueryExecutor.Call(qry, HandleResults, HandleError);
            Console.WriteLine("Call began on seperate thread, execution continued");
            Console.ReadLine();
        }
        public static void HandleResults(IEnumerable<int> results)
        {
            //the results are available in here
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
        public static void HandleError(Exception ex)
        {
            Console.WriteLine("error");
        }
        //just a sample lazy loading enumerable
        public static IEnumerable<int> TestSlowLoadingEnumerable()
        {
            Thread.Sleep(5000);
            foreach (var i in new int[] { 1, 2, 3, 4, 5, 6 })
            {
                yield return i;
            }
        }
    }
