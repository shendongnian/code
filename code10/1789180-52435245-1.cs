    using System;
    using System.Collections.Generic;
    
    class MainClass {
        public static void Main(string[] args) {
            Dictionary<int, List<int>> nest = new Dictionary<int, List<int>>()
            {
                {825, new List<int> {838, 27}},
                {838, new List<int> {2941, 23}},
                {2941, new List<int> {556, 612}},
                {23, new List<int> {66}},
            };
    
            foreach (var row in FindTerminatingPaths(825, nest)) 
            {
                foreach (var cell in row) 
                {
                    Console.Write(cell + " ");
                }
    
                Console.WriteLine();
            }
        }
    
        static List<List<int>> FindTerminatingPaths(int start, Dictionary<int, List<int>> nest)
        {
            List<List<int>> result = new List<List<int>>();
            Dictionary<int, int> parent = new Dictionary<int, int>();
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
    
            while (q.Count > 0) 
            {
                int current = q.Dequeue();
    
                if (nest.ContainsKey(current))
                {
                    foreach (int n in nest[current])
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
    
                    path.Insert(0, start);
                    result.Add(path);
                }
            }
    
            return result;
        }
    }
