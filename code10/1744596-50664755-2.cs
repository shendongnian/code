    public abstract class PipelineBase<InputType, ProcessorInputType, OutputType> : IPipeline<InputType, OutputType>
    {
        protected IProcessor<ProcessorInputType, OutputType> currentProcessor;
        public PipelineBase(IProcessor<ProcessorInputType, OutputType> processor)
        {
            currentProcessor = processor;
        }
        public IPipeline<InputType, ProcessorOutputType> AppendProcessor<ProcessorOutputType>(IProcessor<OutputType, ProcessorOutputType> processor)
        {
            return new Pipeline<InputType, OutputType, ProcessorOutputType>(processor, this);
        }
        public OutputType Execute(InputType input, out Context context)
        {
            context = new Context();
            context.ProcessStartedAt = DateTime.Now;
            var result = ExecuteSubPipeline(input, context);
            context.ProcessEndedAt = DateTime.Now;
            return result;
        }
        public abstract OutputType ExecuteSubPipeline(InputType input, Context context);
    }
