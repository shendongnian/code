    public IEnumerable<IEnumerable<string>> GetTriples(string[] myArray)
    {
        for (int i = 0; i < myArray.Length - 2; i++)
        {
            yield return myArray.Skip(i).Take(3);
        }
    }
