    public static class Extension
    {
    public static void Fill<T>(this List<T> source, List<T> reference, int maxCount,ref int index)
    {
    
    	if(source.Count() >= maxCount) return;
    	var difference = source.Count() - maxCount;
    	source.AddRange(reference.Skip(index).Where(x=>!source.Contains(x)).Take(maxCount- source.Count()));
    	
    	if(source.Count()<maxCount)
    	{
    	    var rnd = new Random();
    		source.AddRange(reference.Where(x=>!source.Contains(x)).OrderBy(x => rnd.Next()).Take(maxCount-source.Count()));
    	}
    	index+=Math.Abs(difference);
    	if(index > maxCount) index = 0;
    }
    }
