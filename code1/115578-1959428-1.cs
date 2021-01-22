    class ConsoleAlgorithm : IAlgorithm
    {
        string name;
        public ConsoleAlgorithm(string algorithmName)
        { 
            this.name = algorithmName;
        }
        public void UpdateProgress(double percent)
        {
            if(percent == 0)
                Console.WriteLine();
            else if (percent == 1.0)
                Console.WriteLine("100%        ");
            else
                Console.Write("\r{0}%", percent * 100);
        }
        public void Complete(bool success)
        {
            if (success)
                Console.WriteLine("{0} completed successfully.", this.name);
            else
                Console.WriteLine("{0} failed.");
        }
        public void Error(string error)
        {
            Console.WriteLine("{0} received error: {1}", this.name, error);
        }
    }
    public class ConsoleAlgorithmFactory: IAlgorithmFactory
    {
        public IAlgorithm StartAlgorithm(string name)
        {
            return new ConsoleAlgorithm(name);
        }
    }
