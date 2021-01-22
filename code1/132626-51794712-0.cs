    public class SwitchCaseIndependent : IEnumerable<KeyValuePair<string, Action>>
    {
        private readonly Dictionary<string, Action> _cases = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        public void Add(string theCase, Action theResult)
        {
            _cases.Add(theCase, theResult);
        }
        public Action this[string whichCase]
        {
            get
            {
                if (!_cases.ContainsKey(whichCase))
                {
                    throw new ArgumentException($"Error in SwitchCaseIndependent, \"{whichCase}\" is not a valid option");
                }
                //otherwise
                return _cases[whichCase];
            }
        }
        public IEnumerator<KeyValuePair<string, Action>> GetEnumerator()
        {
            return _cases.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cases.GetEnumerator();
        }
    }
