    public string CheckRange(int start, int end)
    {
    	NumberLine other = new NumberLine();
    	
    	other.AddRange(start, end);
    	
    	IEnumerable<int> marked = other.Intersect(this);
    	IEnumerable<int> notMarked = other.Except(this);
    	
    	int markedMin = marked.Min();
    	int markedMax = marked.Max();
    	int notMarkedMin = notMarked.Min();
    	int notMarkedMax = notMarked.Max();
    	
    	string markedString = (markedMin == markedMax)
    			? markedMin.ToString()
    			: string.Format("{0} - {1}", markedMin, markedMax);
    	
    	string notMarkedString = (notMarkedMin == notMarkedMax)
    			? notMarkedMin.ToString()
    			: string.Format("{0} - {1}", notMarkedMin, notMarkedMax);
    	
    	return string.Format("Marked: {0}\r\nNot Marked: {1}", markedString, notMarkedString);
    }
