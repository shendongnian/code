        public void layoutNodeY()
        {
            NetNode n1 = startNodes.First();
            n1.VY = 0;
            Dictionary<float, List<NetNode>> nodes = 
                              new Dictionary<float, List<NetNode>>();
            foreach (var n in theNodes)
            {
                if (nodes.Keys.Contains(n.VX)) nodes[n.VX].Add(n);
                else nodes.Add(n.VX, new List<NetNode>() { n });
            }
            for (int i = 0; i < nodes.Count; i++)
            {
                int c = nodes[i].Count;
                for (int j = 0; j < c; j++)
                {
                    nodes.Values.ElementAt(i)[j].VY = 1f * j - c / 2;
                }
            }
            float min = theNodes.Select(x => x.VY).Min();
            foreach (var n in theNodes) n.VY -= min;
        }
