    public static class ExtensionMethods
    {
        static public async Task<List<T>> ToListAsync<T>(this IEnumerable<Task<T>> This)
        {
            var tasks = This.ToList();     //Force LINQ to iterate and create all the tasks. Tasks always start when created.
            var results = new List<T>();   //Create a list to hold the results (not the tasks)
            foreach (var item in tasks)
            {
                results.Add(await item);   //Await the result for each task and add to results list
            }
            return results;
        }
    }
