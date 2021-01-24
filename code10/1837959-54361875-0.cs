    public static async Task Do()
    {
        Task<int[]> parent = Task.Factory.StartNew
        (
            () =>
            {
                var results = new int[3];
                Task.Factory.StartNew(() => results[0] = 0, TaskCreationOptions.AttachedToParent);
                Task.Factory.StartNew(() => results[1] = 1, TaskCreationOptions.AttachedToParent);
                Task.Factory.StartNew(() => results[2] = 2, TaskCreationOptions.AttachedToParent);
                return results;
            }
        , TaskCreationOptions.None);
        var ints = await parent;
        foreach (var i in ints)
        {
            Console.WriteLine("res {0}", i);
        }
    }
