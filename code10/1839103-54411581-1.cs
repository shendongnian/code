    public Task WriteFiles(IEnumerable<string> destinationFolders, string content)
    {
        byte[] bytes = Convert.FromBase64String(content);
        IList<Task> tasks = new List<Task>();
        foreach (var folder in destinationFolders)
        {
            // <snipped>
            Func<Task> taskFactory = async () =>
            {
                using (var imageFile = new FileStream(fullName, FileMode.Create))
                {
                    await imageFile.WriteAsync(bytes, 0, bytes.Length);
                    await imageFile.FlushAsync();
                }
            };
            tasks.Add(taskFactory());
            // <snipped>
        }
        return Task.WhenAny(tasks);
    }
