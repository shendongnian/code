    string[,] arr = new string[3, 3]
    {
            { "a", "b", "c" },
            { "a", "b", "c" },
            { "d", "e", "f" },
    };
    int dim1 = arr.GetLength(0);
    int dim2 = arr.GetLength(1);
    List<string> temp = new List<string>();
    string st;
    for (int i = 0; i < dim1; i++)
    {
        st = "";
        for (int j = 0; j < dim2; j++)
            st += arr[i, j] + ",";
        temp.Add(st);
    }
    var gr = temp.GroupBy(i => i);
    foreach (var g in gr)
        Console.WriteLine($"{g.Key} = {g.Count()}");
