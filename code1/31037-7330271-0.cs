    class Options
    {
        [Option("i", "input", Required = true, HelpText = "Input file to read.")]
        public string InputFile = null;
    
        [Option(null, "lenght", HelpText = "The maximum number of bytes to process.")]
        public int MaximumLenght = -1;
    
        [Option("v", null, HelpText = "Print details during execution.")]
        public bool Verbose = false;
    
        [HelpOption(HelpText = "Dispaly this help screen.")]
        public string GetUsage()
        {
            var usage = new StringBuilder();
            usage.AppendLine("Quickstart Application 1.0");
            usage.AppendLine("Read user manual for usage instructions...");
            return usage.ToString();
        }
    }
