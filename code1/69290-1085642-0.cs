    static void PrintNamesAndAges(IEnumerable<string> names, IEnumerable<int> ages)
    {
        using (IEnumerator<int> ageIterator = ages.GetEnumerator())
        {
            foreach (string name in names)
            {
                if (!ageIterator.MoveNext())
                {
                    throw new ArgumentException("Not enough ages");
                }
                Console.WriteLine("{0} is {1} years old", name, ageIterator.Current);
            }
            if (ageIterator.MoveNext())
            {
                throw new ArgumentException("Not enough names");
            }
        }
    }
