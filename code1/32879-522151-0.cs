    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    class VertexCover
    {
        static void Main(string[] args)
        {
            var v = new VertexCover();
            v.ParseInput();
            v.FindVertexCover();
            v.PrintResults();
        }
    
        private void PrintResults()
        {
            Console.WriteLine(String.Join(" ", VertexCoverResult.Select(x => x.ToString()).ToArray()));
        }
    
        private void FindVertexCover()
        {
            FindBipartiteMatching();
    
            var TreeSet = new HashSet<int>();
            foreach (var v in LeftVertices)
                if (Matching[v] < 0)
                    DepthFirstSearch(TreeSet, v, false);
    
            VertexCoverResult = new HashSet<int>(LeftVertices.Except(TreeSet).Union(RightVertices.Intersect(TreeSet)));
        }
    
        private void DepthFirstSearch(HashSet<int> TreeSet, int v, bool left)
        {
            if (TreeSet.Contains(v))
                return;
            TreeSet.Add(v);
            if (left) {
                foreach (var u in Edges[v])
                    if (u != Matching[v])
                        DepthFirstSearch(TreeSet, u, true);
            } else if (Matching[v] >= 0)
                DepthFirstSearch(TreeSet, Matching[v], false);
    
        }
    
        private void FindBipartiteMatching()
        {
            Bicolorate();
            Matching = Enumerable.Repeat(-1, VertexCount).ToArray();
            var cnt = 0;
            foreach (var i in LeftVertices) {
                var seen = new bool[VertexCount];
                if (BipartiteMatchingInternal(seen, i)) cnt++;
            }
        }
    
        private bool BipartiteMatchingInternal(bool[] seen, int u)
        {
            foreach (var v in Edges[u]) {
                if (seen[v]) continue;
                seen[v] = true;
                if (Matching[v] < 0 || BipartiteMatchingInternal(seen, Matching[v])) {
                    Matching[u] = v;
                    Matching[v] = u;
                    return true;
                }
            }
            return false;
        }
    
        private void Bicolorate()
        {
            LeftVertices = new HashSet<int>();
            RightVertices = new HashSet<int>();
    
            var colors = new int[VertexCount];
            for (int i = 0; i < VertexCount; ++i)
                if (colors[i] == 0 && !BicolorateInternal(colors, i, 1))
                    throw new InvalidOperationException("Graph is NOT bipartite.");
        }
    
        private bool BicolorateInternal(int[] colors, int i, int color)
        {
            if (colors[i] == 0) {
                if (color == 1) LeftVertices.Add(i);
                else RightVertices.Add(i);
                colors[i] = color;
            } else if (colors[i] != color)
                return false;
            else
                return true;
            foreach (var j in Edges[i])
                if (!BicolorateInternal(colors, j, 3 - color))
                    return false;
            return true;
        }
    
        private int VertexCount;
        private HashSet<int>[] Edges;
        private HashSet<int> LeftVertices;
        private HashSet<int> RightVertices;
        private HashSet<int> VertexCoverResult;
        private int[] Matching;
    
        private void ReadIntegerPair(out int x, out int y)
        {
            var input = Console.ReadLine();
            var splitted = input.Split(new char[] { ' ' }, 2);
            x = int.Parse(splitted[0]);
            y = int.Parse(splitted[1]);
        }
    
        private void ParseInput()
        {
            int EdgeCount;
            ReadIntegerPair(out VertexCount, out EdgeCount);
            Edges = new HashSet<int>[VertexCount];
            for (int i = 0; i < Edges.Length; ++i)
                Edges[i] = new HashSet<int>();
    
            for (int i = 0; i < EdgeCount; i++) {
                int x, y;
                ReadIntegerPair(out x, out y);
                Edges[x].Add(y);
                Edges[y].Add(x);
            }
        }
    }
