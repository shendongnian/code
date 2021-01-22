    public class ConfirmationProvider : IConfirmationProvider
    {
        private readonly TextReader input;
        private readonly TextWriter output;
        public ConfirmationProvider() : this(Console.In, Console.Out)
        {
        }
        public ConfirmationProvider(TextReader input, TextWriter output)
        {
            this.input = input;
            this.output = output;
        }
        public bool Confirm(string operation)
        {
            output.WriteLine($"Confirmed operation {operation}...");
            if (input.ReadLine().Trim().ToLower() != "y")
            {
                output.WriteLine("Aborted!");
                return false;
            }
            output.WriteLine("Confirmated!");
            return true;
        }
    }
