    List<int> trianglesList = new List<int> { };
    List<int> OLtrianglesList = new List<int> { };
    for (int i = 0; i < (n - 2); i++)
    {
        trianglesList.Add(0);
        trianglesList.Add(i + 1);
        trianglesList.Add(i + 2);
    }
    for (int i = 0; i < (n - 2); i++)
    {
        trianglesList.Add(n);
        trianglesList.Add(i + n + 1);
        trianglesList.Add(i + n + 2);
    }
