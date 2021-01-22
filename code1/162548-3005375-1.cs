    using (var results = ..)
    {
        foreach (var result in results)
        {
            using (result)
            {
                ...
            }
        }
    }
