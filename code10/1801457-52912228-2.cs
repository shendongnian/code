    public static async Task DoStuffAsync(Content[] contents, string siteurl, string src, string target)
    {
    
       async Task<(Content, SomeResponse)> PostAsyncWrapper(Content content)
       {
          return (content, await PostAsync(content, siteurl, src, target));
       }
    
       var bufferblock = new BufferBlock<(Content, SomeResponse)>();
       var actionBlock = new TransformBlock<Content, (Content, SomeResponse)>(
          content => PostAsyncWrapper(content),
          new ExecutionDataflowBlockOptions
             {
                EnsureOrdered = false,
                MaxDegreeOfParallelism = 100,
                SingleProducerConstrained = true
             });
       actionBlock.LinkTo(bufferblock);
    
       foreach (var content in contents)
          actionBlock.Post(content);
    
       actionBlock.Complete();
       await actionBlock.Completion;
    
       if (bufferblock.TryReceiveAll(out var result))
       {
          // do stuff with your results pairs here   
       }
    
    }
    
