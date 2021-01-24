    public class ProcessFilesFlow
    {
        private TransformBlock<SourcePath, IEnumerable<SourceFile>> _getSourceFileBatch;
        private TransformBlock<IEnumerable<SourceFile>, IEnumerable<SourceFile>> _setStatusToProcessing;
        private TransformBlock<IEnumerable<SourceFile>, IEnumerable<SourceFile>> _processFiles;
        private ActionBlock<IEnumerable<SourceFile>> _setStatusToComplete;
        
        public ProcessFilesFlow()
        {
            //Setup options
            //All of these options and more can be tuned for throughput
            var getSourceFileBatchOptions = new ExecutionDataflowBlockOptions()
            {
                BoundedCapacity = 10, //How many source paths to queue at one time
                MaxDegreeOfParallelism = 10, //How many source paths to get batches for at one time
                EnsureOrdered = false //Process batches as soon as ready
            };
            var setStatusToProcessingOptions = new ExecutionDataflowBlockOptions()
            {
                BoundedCapacity = 10, //How many batches to queue at one time
                MaxDegreeOfParallelism = 10, //Unlimited, how many batches to updates status for
                EnsureOrdered = false //Process batches as soon as ready
            };
            var processFilesOptions = new ExecutionDataflowBlockOptions()
            {
                BoundedCapacity = 10, //Batches to queue at one time
                MaxDegreeOfParallelism = 10, //Batches to work on at the same time
                EnsureOrdered = false //Process batches as soon as ready
            };
            var setStatusToCompleteOptions = new ExecutionDataflowBlockOptions()
            {
                BoundedCapacity = 10, //Batches to queue at one time
                MaxDegreeOfParallelism = 10, //Batches to update at once
                EnsureOrdered = false //Process batches as soon as ready
            };
            
            //Build the dataflow pipeline
            _getSourceFileBatch = new TransformBlock<SourcePath, IEnumerable<SourceFile>>(path => GetSourceFileBatch(path), getSourceFileBatchOptions);
            _setStatusToProcessing = new TransformBlock<IEnumerable<SourceFile>, IEnumerable<SourceFile>>(batch => SetStatusToProcessingAsync(batch), setStatusToProcessingOptions);
            _processFiles = new TransformBlock<IEnumerable<SourceFile>, IEnumerable<SourceFile>>(batch => ProcessFiles(batch), processFilesOptions);
            _setStatusToComplete = new ActionBlock<IEnumerable<SourceFile>>(batch => SetStatusToCompleteAsync(batch), setStatusToCompleteOptions);
    
            //Link the pipeline
            _getSourceFileBatch.LinkTo(_setStatusToProcessing, new DataflowLinkOptions() { PropagateCompletion = true });
            _setStatusToProcessing.LinkTo(_processFiles, new DataflowLinkOptions() { PropagateCompletion = true });
            _processFiles.LinkTo(_setStatusToComplete, new DataflowLinkOptions() { PropagateCompletion = true });
        }
    
        public async Task ProcessAll(IEnumerable<SourcePath> sourcePaths)
        {
            foreach(var path in sourcePaths)
            {
                await _getSourceFileBatch.SendAsync(path);
            }
            _getSourceFileBatch.Complete();
            await _setStatusToComplete.Completion;
        }
    
        private IEnumerable<SourceFile> GetSourceFileBatch(SourcePath sourcePath)
        {
            //Get batch of files based on sourcePath
            return Enumerable.Empty<SourceFile>();
        }
    
        private async Task<IEnumerable<SourceFile>> SetStatusToProcessingAsync(IEnumerable<SourceFile> sourceFiles)
        {
            //Update file status
            foreach (var file in sourceFiles)
                await file.UpdateStatusAsync("In Progress");
            return sourceFiles;
        }
    
        private IEnumerable<SourceFile> ProcessFiles(IEnumerable<SourceFile> sourceFiles)
        {
            //process files
            foreach (var file in sourceFiles)
                file.Process();
            return sourceFiles;
        }
    
        private async Task SetStatusToCompleteAsync(IEnumerable<SourceFile> sourceFiles)
        {
            //Update file status
            foreach (var file in sourceFiles)
                await file.UpdateStatusAsync("Completed");
        }
    }
