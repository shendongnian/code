    var tasks = new List<Task>();
    foreach (var item in Images) 
    {
        // item.File is IFormFile array
        tasks.Add(SaveFile(item.FileSavePath, item.File));
    }
    await Task.WhenAll(tasks);
