    public int[] graph1VertexList = new int[] { 1, 2, 3, 4, 5, 6, 7 };
    public int[,] graph1 = new int[7, 7];
    public bool[] visited = new bool[7]; // new array, initialized to false
    public void bfs()
    {
        Console.Write(graph1VertexList[0]);//print the first value
        for (int i = 0; i < graph1VertexList.Length; i++)
        {
            for (int z = 0; z < graph1VertexList.Length; z++)
            {
                if (graph1[i, z] == 1 && !visited[z])   // check for visit
                {
                    visited[z] = true;                  // mark as visited
                    Console.Write(graph1VertexList[z]);
                }
            }
        }
    }
