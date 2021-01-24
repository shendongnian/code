    System.Collections.Concurrent.ConcurrentBag<string> listResult = new System.Collections.Concurrent.ConcurrentBag<string>();
    System.Threading.Tasks.Parallel.ForEach<string>(list2, str2 =>
    {
        foreach (string str1 in list1)
        {
            if (str2.Contains(str1))
            {
                listResult.Add(str2);
            }
        }
    });
