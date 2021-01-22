        int[] array = null;
        foreach (int i in array ?? new int[0])
        {
            System.Console.WriteLine(string.Format("{0}", i));
        }
