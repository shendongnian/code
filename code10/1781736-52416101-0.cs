    public class Program
    {
        private static List<string> CalledMethods = new List<string>();
        static bool ShouldIRun(string methodName)
        {
            if (CalledMethods.Contains(methodName)) return false;
            CalledMethods.Add(methodName);
            return true;
        }
        // Now this method can use method above to return early (do nothing) if it's already ran
        static void OnlyCalledOnce()
        {
            if (!ShouldIRun("OnlyCalledOnce")) return;
            Console.WriteLine("You should only see this once.");
        }
        // Let's test it out
        private static void Main()
        {
            OnlyCalledOnce();
            OnlyCalledOnce();
            OnlyCalledOnce();
            GetKeyFromUser("\nDone! Press any key to exit...");
        }
    }
