    public void ListCounters(string categoryName)
    {
        PerformanceCounterCategory category = PerformanceCounterCategory.GetCategories().First(c => c.CategoryName == categoryName);
        Console.WriteLine("{0} [{1}]", category.CategoryName, category.CategoryType);
        string[] instanceNames = category.GetInstanceNames();
        if (instanceNames.Length > 0)
        {
            // MultiInstance categories
            foreach (string instanceName in instanceNames)
            {
                ListInstances(category, instanceName);
            }
        }
        else
        {
            // SingleInstance categories
            ListInstances(category, string.Empty);
        }
    }
    private static void ListInstances(PerformanceCounterCategory category, string instanceName)
    {
        Console.WriteLine("    {0}", instanceName);
        PerformanceCounter[] counters = category.GetCounters(instanceName);
        foreach (PerformanceCounter counter in counters)
        {
            Console.WriteLine("        {0}", counter.CounterName);
        }
    }
