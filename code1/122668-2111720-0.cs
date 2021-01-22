    public class Processor
    {
    
        public void Process(IRepository repository)
        {
            // Do some stuff ...
    
            IEnumerable<IBaseInput> inputs = repository.GetInputs();
            IEnumerable<IBaseResult> results = repository.GetResults();
    
            // Do some stuff with inputs and outputs...
        }
    }
