    public interface IChainProcessor
    {
        IChainOutput Run(IChainOutput previousOutput);
    }
    
    public interface IChainOutput
    {
        string Value { get; }
    }
    
    public class OutputExample : IChainOutput
    {
        public string Value { get; }
    
        public OutputExample(string value)
        {
            this.Value = value;
        }
    }
    
    public abstract class Processor : IChainProcessor
    {
        protected IChainProcessor nextProcessor;
    
        public IChainOutput Run(IChainOutput previousOutput)
        {
            var myOutput = this.MyLogic(previousOutput);
    
            return this.nextProcessor == null ? myOutput : this.nextProcessor.Run(myOutput);
        }
    
        protected abstract IChainOutput MyLogic(IChainOutput input);
    }
    
    public class ProcessorA : Processor
    {
        public ProcessorA() { }
    
        public ProcessorA(ProcessorB nextProcessor)
        {
            this.nextProcessor = nextProcessor;
        }
    
        protected override IChainOutput MyLogic(IChainOutput input)
        {
            return new OutputExample($"{input.Value} + Processor_A_Output"); 
        }
    }
    
    public class ProcessorB : ProcessorA
    {
        public ProcessorB() { }
    
        public ProcessorB(ProcessorC nextProcessor)
        {
            this.nextProcessor = nextProcessor;
        }
    
        protected override IChainOutput MyLogic(IChainOutput input)
        {
            return new OutputExample($"{input.Value} + Processor_B_Output");  
        }
    }
    
    public class ProcessorC : ProcessorB
    {
        protected override IChainOutput MyLogic(IChainOutput input)
        {
            return new OutputExample($"{input.Value} + Processor_C_Output"); 
        }
    }
