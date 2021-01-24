    public static class Extensions
    {
    public static JToken RemoveFields(this JToken token)
    {
    	JContainer container = token as JContainer;
        if (container == null) return token;
    
        List<JToken> removeList = new List<JToken>();
        foreach (JToken el in container.Children())
        {
        	JProperty p = el as JProperty;
            if (p != null && p.Name.StartsWith("#"))
            {
            	removeList.Add(el);
            }
            el.RemoveFields();
        }
    
        foreach (JToken el in removeList)
        	el.Remove();
    
        return token;
    }
    }
