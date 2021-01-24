    public abstract class CollectionPipe<TInput, TOutput> : PipeItem<List<TInput>, List<TOutput>>
    {
        protected CollectionPipe(IPipeline<List<TInput>> nextPipeItem) : base(nextPipeItem)
        {
        }
    
        public override List<TOutput> Process()
        {
            return nextPipeItem.Process().Select(ProcessOne).ToList();
        }
    
        protected abstract TOutput ProcessOne(TInput input);
    
    }
    
