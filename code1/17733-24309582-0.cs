    public class StackOverflow
    {
        private IEnumerable<string> _definitions;
        public IEnumerable<string> Definitions
        {
            get
            {
                return _definitions ?? (
                    _definitions = new List<string>
                    {
                        "definition 1",
                        "definition 2",
                        "definition 3"
                    }
                );
            }
        } 
    }
