    public static class Pipeline
    {
        public static TerminalPipeline<InputType, OutputType> Create<InputType, OutputType>(IProcessor<InputType, OutputType> processor)
        {
            return new TerminalPipeline<InputType, OutputType>(processor);
        }
    }
