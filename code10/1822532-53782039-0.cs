    int[] value = Enumerable.Range(1, 112).ToArray();
    int[] response = Enumerable.Range(1, 47).ToArray();
    List<int> modelBank = new List<int>();
    for (var i = 0; i<value.Length; i++)
    {
        if (!response.Any(x => x == value[i]))
        {
            modelBank.Add(value[i]);
        }
    }
