    string[] lines = File.ReadAllLines("ints.txt");
    Graph g = new Graph();
    for(int i =0; i< lines.Liength; i++)
    {
         string[] ints = lines[i].Split(' ');
         Dictionary<int, int> dict = new Dictionary<int, int>();
         for(int j = 0; j<ints.Length;j++)
            dict.Add(int.Parse(ints[i].Trim()), stack.Pop());
         g.add_vertex(i+1, dict);
    }
