    public class Inputs {
        private string[] _args;
        public string InputFolder { get { return _args[0]; } }
        public string OutputFolder { get { return _args[1]; } }
        public Inputs(string[] args) { _args = args; }
    }
