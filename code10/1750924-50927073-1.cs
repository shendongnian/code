    public void DFS(Graph g)
    {
         Stack<int> stk = new Stack<int>();
         HashSet<int> visited = new HashSet<int>();
    
         stk.Push(g.Vertex);
         visited[0] = g.Vertex;
         while (stk.Count > 0)
         {
             int current = stk.Pop();
             Console.WriteLine(current);
             foreach (var item in dict[current])
             {
                 if (visited.Add(item))
                 {
                     // Add returns true if the element wasn't in the set already
                     stk.Push(item);
                 }
             }
        }
    }
