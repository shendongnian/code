    public class TerminalPipeline<InputType, OutputType> : PipelineBase<InputType, InputType, OutputType>
    {       
        public TerminalPipeline(IProcessor<InputType, OutputType> processor)
            :base(processor)
        { }
        public override OutputType ExecuteSubPipeline(InputType input, Context context)
        {
            return currentProcessor.Process(input, context);
        }
    }
    public class Pipeline<InputType, ProcessorInputType, OutputType> : PipelineBase<InputType, ProcessorInputType, OutputType>
    {
        IPipeline<InputType, ProcessorInputType> previousPipeline;
        public Pipeline(IProcessor<ProcessorInputType, OutputType> processor, IPipeline<InputType, ProcessorInputType> previousPipeline)
            : base(processor)
        {
            this.previousPipeline = previousPipeline;
        }
        public override OutputType ExecuteSubPipeline(InputType input, Context context)
        {
            var previousPipelineResult = previousPipeline.ExecuteSubPipeline(input, context);
            return currentProcessor.Process(previousPipelineResult, context);
        }
    }
