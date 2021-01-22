    public class DomElement : XElement
    {
    	public DomElement(string name) : base(name)
    	{
    	}
    
    	public DomElement(string name, string value) : base(name, value)
    	{
    	}
    
    	public DomElement Css(string style, string value)
    	{
    		style = style.Trim();
    		value = value.Trim();
    		var existingStyles = new Dictionary<string, string>();
    		var xstyle = this.Attribute("style");
    		if (xstyle != null)
    		{
    			foreach (var s in xstyle.Value.Split(';'))
    			{
    				var keyValue = s.Split(':');
    				existingStyles.Add(keyValue[0], keyValue.Length < 2 ? null : keyValue[1]);
    			}
    		}
    
    		if (existingStyles.ContainsKey(style))
    		{
    			existingStyles[style] = value;
    		}
    		else
    		{
    			existingStyles.Add(style, value);
    		}
    
    		var styleString = string.Join(";", existingStyles.Select(s => $"{s.Key}:{s.Value}"));
    		this.SetAttributeValue("style", styleString);
    
    		return this;
    	}
    
    	public DomElement AddClass(string cssClass)
    	{
    		var existingClasses = new List<string>();
    		var xclass = this.Attribute("class");
    		if (xclass != null)
    		{
    			existingClasses.AddRange(xclass.Value.Split());
    		}
    
    		var addNewClasses = cssClass.Split().Where(e => !existingClasses.Contains(e));
    		existingClasses.AddRange(addNewClasses);
    
    		this.SetAttributeValue("class", string.Join(" ", existingClasses));
    		return this;
    	}
    
    	public DomElement Text(string text)
    	{
    		this.Value = text;
    		return this;
    	}
    
    	public DomElement Append(string text)
    	{
    		this.Add(text);
    		return this;
    	}
    	
    	public DomElement Append(DomElement child)
    	{
    		this.Add(child);
    		return this;
    	}
    }
