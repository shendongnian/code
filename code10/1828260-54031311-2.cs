    public static void RemainingDegreeDistribution<TMatrix>(IGraph graph, TMatrix distArr)
    	where TMatrix : IMatrix<float>
    {
    	int total = 0;
    	for (int i = 0; i < graph.Edges.Count; i++)
    	{
    		int startRemDeg = graph.Edges[i].Start.RemDeg;
    		int endRemDeg = graph.Edges[i].End.RemDeg;
    		distArr[startRemDeg, endRemDeg]++;
    		distArr[endRemDeg, startRemDeg]++;
    		total = total + 2;
    	}
    
    	for (int i = 0; i < distArr.Rows; i++)
    	{
    		for (int j = 0; j < distArr.Columns; j++)
    		{
    			distArr[i, j] /= total;
    		}
    	}
    }
