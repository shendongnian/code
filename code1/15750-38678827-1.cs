    public async Task WriteNamesToConsoleAsync(string connectionString, CancellationToken token = default(CancellationToken))
    {
        using (var ctx = new DataContext(connectionString))
        {
            var query = from item in Products where item.Price > 3 select item.Name;
            var result = await ExecuteAsync(query, ctx, token);
            foreach (var name in result)
            {
                Console.WriteLine(name);
            }
        }
    }
