    public static class Extension
    {
    	public static bool AllViewed(this List<Phrase> source)
    	{
    		return source.All(x=>x.Viewed)
    	}
    }
