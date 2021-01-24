    void Main()
    {
    	List<Line> lines = new List<Line>();
    	var comparer = LineEqualityComparer.Instance;
    	var filtered = lines
            .Select((line, idx) => new { line, idx })
            .GroupBy(x => x.line, comparer)
            .Where(g => g.Count() == 1)
            .SelectMany(g => g)
            .OrderBy(x => x.idx)
            .Select(x => x.line);
    }
    
    class Line
    {
    	public int X1 { get; }
    	public int Y1 { get; }
    	public int X2 { get; }
    	public int Y2 { get; }
    }
    
    class LineEqualityComparer : IEqualityComparer<Line>
    {
    	public static IEqualityComparer<Line> Instance { get; } = new LineEqualityComparer();
    	public bool Equals(Line x, Line y)
    	{
    		//fill-in the blanks
    	}
    
    	public int GetHashCode(Line obj)
    	{
    		//fill-in the blanks
    	}
    }
