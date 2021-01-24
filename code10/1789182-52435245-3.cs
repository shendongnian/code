    using System;
    using System.Collections.Generic;
    
    class MainClass {
        public static void Main(string[] args) {
            Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>()
            {
                {825, new List<int> {838, 27}},
                {838, new List<int> {2941, 23}},
                {2941, new List<int> {556, 612}},
                {23, new List<int> {66}},
            };
    
            foreach (var row in FindPathsToLeaves(825, tree))
            {
                foreach (var cell in row) 
                {
                    Console.Write(cell + " ");
                }
    
                Console.WriteLine();
            }
        }
    
        static List<List<int>> FindPathsToLeaves(int root, Dictionary<int, List<int>> tree)
        {
            List<List<int>> paths = new List<List<int>>();
            Dictionary<int, int> parent = new Dictionary<int, int>();
            parent[root] = -1;
            Queue<int> q = new Queue<int>();
            q.Enqueue(root);
    
            while (q.Count > 0) 
            {
                int current = q.Dequeue();
    
                if (tree.ContainsKey(current))
                {
                    foreach (int n in tree[current])
                    {
                        parent[n] = current;
                        q.Enqueue(n);
                    }
                } 
                else
                {
                    List<int> path = new List<int>();
    
                    while (parent.ContainsKey(current))
                    {
                        path.Insert(0, current);
                        current = parent[current];
                    }
    
                    paths.Add(path);
                }
            }
    
            return paths;
        }
    }
