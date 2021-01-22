    public static class FontCache
    {
    	public static FontSource MyCoolFontSource { get; set; }
    
    	static FontCache()
    	{
    		using (Stream fontStream = ...)
    		{
    			FontCache.MyCoolFontSource = new FontSource(fontStream);
    		}
    	}
    }
