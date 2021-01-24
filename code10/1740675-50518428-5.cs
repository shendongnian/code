    public class Parser
    {
        public List<ParserStep> Steps { get; set; } = new List<ParserStep>();
        public void Run(string message)
        {
            foreach (var step in Steps)
            {
                if (string.IsNullOrEmpty((message)))
                    return;
                message = step.ProcessStep(message);
                message = message.TrimStart('-');
            }
        }
    }
