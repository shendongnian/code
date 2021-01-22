        int[] array = null;
        foreach (int i in array ?? Enumerable.Empty<int>())
        {
            System.Console.WriteLine(string.Format("{0}", i));
        }
