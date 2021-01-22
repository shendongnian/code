    var filesContent = from file in enumerableOfFilesToProcess
                       select new 
                       {
                           File=file, 
                           Content=File.ReadAllText(file)
                       };
    var processedContent = from content in filesContent.AsParallel()
                           select new 
                           {
                               content.File, 
                               ProcessedContent = ProcessContent(content.Content)
                           };
    var dictionary = processedContent.ToDictionary(c => c.File);
