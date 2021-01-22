    ICollection<int> test = new List<int>(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
    foreach (int myInt in test.Reverse<int>())
    {
        if (myInt % 2 == 0)
        {
            test.Remove(myInt);
        }
    }
