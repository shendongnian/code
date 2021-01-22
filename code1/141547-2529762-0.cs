    public struct AlgorithmParameters
    {
        public readonly int Parameter1;
        public readonly int Parameter2;
        public AlgorithmParameters(int parameter1, int parameter2)
        {
            Parameter1 = parameter1;
            Parameter2 = parameter2;
        }
    }
    public class RecursiveAlgorithm
    {
        private Stack<AlgorithmParameters> _parameterStack = new Stack<AlgorithmParameters>();
        public IEnumerable<AlgorithmParameters> ParameterStack
        {
            get { return _parameterStack; }
        }
        public IEnumerable<RecursiveAlgorithm> RunAlgorithm(int parameter1, int parameter2)
        {
            return RunAlgorithm(new AlgorithmParameters(parameter1, parameter2));
        }
        public IEnumerable<RecursiveAlgorithm> RunAlgorithm(AlgorithmParameters parameters)
        {
            //Push parameters onto the stack
            _parameterStack.Push(parameters);
            //Return the current state of the algorithm before we start running
            yield return this;
            //Now execute the algorithm and return subsequent states
            foreach (var state in Execute())
                yield return state;
        }
        private IEnumerable<RecursiveAlgorithm> Execute()
        {
            //Get the parameters for this recursive call
            var parameters = _parameterStack.Pop();
            //Some algorithm implementation here...
            //If the algorithm calls itself, do this:
            int newParameter1 = 2; //Parameters determined above...
            int newParameter2 = 5;
            foreach (var state in RunAlgorithm(newParameter1, newParameter2))
                yield return state;
            //More implementation here...
            //We've finished one recursive call, so return the current state
            yield return this;
        }
    }
