	void Main()
	{
		const int nNodes = 10;
		var graphAsDict = RandomGraphWithSelfEdgeAsDict(nNodes).Dump("graphAsDict: Random graph as Dict");
		
		var velg1 = graphAsDict.ToVertexAndEdgeListGraph(
		    kv => Array.ConvertAll<int, SEquatableEdge<int>>(
		        kv.Value.ToArray(),
		        v => new SEquatableEdge<int>(kv.Key, v))).Dump("velg1: Vertex and Edge-List Graph");
		Func<SEquatableEdge<int>, double> edgeCost = (edge => 1.0D);
		
		int start = new Random(Guid.NewGuid().GetHashCode()).Next(1, nNodes + 1).Dump("start point");
		int end = new Random(Guid.NewGuid().GetHashCode()).Next(1, nNodes + 1).Dump("end point");
		var algo = new DijkstraShortestPathAlgorithm<int, SEquatableEdge<int>>(velg1, edgeCost);
		var predecessors = new VertexPredecessorRecorderObserver<int, SEquatableEdge<int>>();
		using (predecessors.Attach(algo))
		{
			algo.Compute(start);
			IEnumerable<SEquatableEdge<int>> path;
			if (predecessors.TryGetPath(end, out path).Dump("TryGetPath"))
			    path.Dump("path");
		}
	}
	public static int[] RandomPermutation(Random ran, int n)
	{
		var r = Enumerable.Range(1, n).ToArray();
		for (var i = 0; i < n - 1; i++)
		{
			var k = ran.Next(i + 1, n);
			var t = r[i];
			r[i] = r[k];
			r[k] = t;
		}
		return r;
	}
	public static Dictionary<int, IEnumerable<int>> 
	RandomGraphWithSelfEdgeAsDict(int nNodes)
	{
		var ran = new Random(Guid.NewGuid().GetHashCode());
		var result = new Dictionary<int, IEnumerable<int>>();
		
		for (var j = 1; j <= nNodes; j++)
		{
			var k = ran.Next(0, nNodes);
			var cs = RandomPermutation(ran, nNodes);
			result[j] = cs.Take(k);
		}
		
		return result;
	}
