    public class ParserStep
    {
        public Action<string> ToDo { get; set; }
        public List<Tuple<string, string>> Data { get; set; } = new List<Tuple<string, string>>();
        public bool Optional { get; set; } = false;
        public string ProcessStep(string message)
        {
            foreach (var d in Data)
            {
                if (message.StartsWith(d.Item1))
                {
                    ToDo(d.Item2);
                    return message.Substring(d.Item1.Length);
                }
            }
            if (!Optional)
                throw new InvalidDataException();
            return message;
        }
    }
