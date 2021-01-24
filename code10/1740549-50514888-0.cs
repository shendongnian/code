    static class ExtMethods
    {
    	public static T GetCopy<T>(this UIElement element)
    	{
    		using (var ms = new MemoryStream())
    		{
    			XamlWriter.Save(element, ms);
    			return (T)XamlReader.Load(ms);
    		}
    	}
    }
