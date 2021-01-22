    public static XElement SetNamespace(this XElement src, XNamespace ns)
    {
    	var name = src.isEmptyNamespace() ? ns + src.Name.LocalName : src.Name;
    	var element = new XElement(name, src.Attributes(), 
              from e in src.Elements() select e.SetNamespace(ns));
    	if (!src.HasElements) element.Value = src.Value;
    	return element;
    }
    
    public static bool isEmptyNamespace(this XElement src)
    {
    	return (string.IsNullOrEmpty(src.Name.NamespaceName));
    }
