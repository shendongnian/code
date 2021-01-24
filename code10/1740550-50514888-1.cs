    static class ExtMethods
    {
    	public static T GetCopy<T>(this UIElement element)
    	{
    		using (var ms = new MemoryStream())
    		{
    			XamlWriter.Save(element, ms);
                ms.Seek(0, SeekOrigin.Begin);
    			return (T)XamlReader.Load(ms);
    		}
    	}
    }
