     private static async Task Perform() {
       // Be careful with this parameter: what do you expect the system
       // to do if the pipeline contains pipelineMaxLength items?
       int pipelineMaxLength = 100;
       int consumersCount = 10;
       using (BlockingCollection<string> pipeline = 
         new BlockingCollection<string>(pipelineMaxLength)) {
         // Producer(s)
         using (FileSystemWatcher fsw = new FileSystemWatcher()) {
           ...
           fsw.Created += (s, e) => {
             // whenever new file has been created, add it to the pipeline 
             if (!pipeline.IsAddingCompleted)
               pipeline.Add(e.FullPath);
  
             // Whenever you have no files to add and you want quit processing call
             // pipeline.CompleteAdding();
           };
           // Consumers (consumersCount of them are working in parallel)
           var consumers = Enumerable
            .Range(0, consumersCount) // 
            .Select(index => Task.Run(() => {
               // each consumer extracts file from the pipeline and processes it
               foreach (var file in pipeline.GetConsumingEnumerable()) {
                 //TODO: process the file here 
               } }))
            .ToArray();
           // (a)wait until all the consumers finish their work
           await Task
             .WhenAll(consumers);
         }
       }
     }
