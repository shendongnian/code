    public class Program
    {
		private static int callCount = 0;
        private static int WriteToConsole(int lemmings)
        {
			callCount += 1;
			int currentCall = callCount;
						
			Console.WriteLine("Call number {0} has Lemmings = {1}", currentCall, lemmings);
			int i = lemmings;
			Console.WriteLine("Call number {0} has i = {1}", currentCall, i);
            while (i > 0)
            {
				Console.WriteLine("Call number {0} in the loop top with i = {1}", currentCall, i);
                i = WriteToConsole(i - 1);
				Console.WriteLine("Call number {0} in the loop bottom with i = {1}", currentCall, i);
            }
			Console.WriteLine("Call number {0} is about to return {1}", currentCall, lemmings - 1);
            return lemmings - 1;
        }
        public static void Main(string[] args)
        {
            WriteToConsole(3);
        }
    }
