    public class DataflowPipeline
    {
        private TransformBlock<IEnumerable<int>, IEnumerable<Locals>> Initialize { get; }
        private TransformManyBlock<IEnumerable<Locals>, Locals> Distribute { get; }
        private TransformBlock<Locals, Result> Compute { get; }
        //other blocks, results, disposal etc.
        public DataflowPipeline()
        {
            var sequential = new ExecutionDataflowBlockOptions() { MaxDegreeOfParallelism = 1 };
            var parallel = new ExecutionDataflowBlockOptions() { MaxDegreeOfParallelism = 6 };
            Initialize = new TransformBlock<IEnumerable<int>, IEnumerable<Locals>>(
                inputs => inputs.Select(x => new Locals() { ExpensiveItem = string.Empty, Input = x }),
                sequential);
            Distribute = new TransformManyBlock<IEnumerable<Locals>, Locals>(x => x, sequential);
            Compute = new TransformBlock<Locals, Result>(
                local => new Result() { ExpensiveItem = local.ExpensiveItem, Output = local.Input * 2 },
                parallel);
            //Other blocks, link, complete etc.
        }
    }
