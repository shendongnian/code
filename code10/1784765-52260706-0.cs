     private static async Task Perform() {
       int pipelineMaxLength = 100;
       int consumersCount = 10;
       using (BlockingCollection<string> pipeline = 
         new BlockingCollection<string>(pipelineMaxLength)) {
         // Producer(s)
         FileSystemWatcher fsw = new FileSystemWatcher();
         ...
         
         fsw.Created += (s, e) => {
           // whenever new file has been created, add it to the pipeline
           pipeline.Add(e.FullPath);
  
           // Whenever you have no files to add and you want quit processing
           // pipeline.CompleteAdding();
         };
         // Consumers (consumersCount of them working in parallel)
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
