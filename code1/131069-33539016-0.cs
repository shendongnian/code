        private static void GetAllCounters(string categoryFilter)
        {
        	var categories = PerformanceCounterCategory.GetCategories();
        	foreach (var cat in categories)
        	{
        		if (categoryFilter != null && categoryFilter.Length > 0)
        		{
        			if (!cat.CategoryName.Contains(categoryFilter)) continue;
        		}
        		Console.WriteLine("Category {0}", cat.CategoryName);
        		try
        		{
        			var instances = cat.GetInstanceNames();
        			if (instances != null && instances.Length > 0)
        			{
        				foreach (var instance in instances)
        				{
        					//if (cat.CounterExists(instance))
        					//{
        						foreach (var counter in cat.GetCounters(instance))
        						{
        							Console.WriteLine("\tCounter Name {0} [{1}]", counter.CounterName, instance);
        						}
        					//}
        				}
        			}
        			else
        			{
        				foreach (var counter in cat.GetCounters())
        				{
        					Console.WriteLine("\tCounter Name {0}", counter.CounterName);
        				}
        			}
        		}
        		catch (Exception)
        		{
        			// NO COUNTERS
        		}
        	}
        	Console.ReadLine();
    }
