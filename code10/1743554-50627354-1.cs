    public static string FormatWith(this string format, object source, bool escape = false)
    {
    	return FormatWith(format, null, source, escape);
    }
    
    public static string FormatWith(this string format, IFormatProvider provider, object source, bool escape = false)
    {
    	if (format == null)
    		throw new ArgumentNullException("format");
    
    	List<object> values = new List<object>();
    	var rewrittenFormat = Regex.Replace(format,
    		@"(?<start>\{)+(?<property>[\w\.\[\]]+)(?<format>:[^}]+)?(?<end>\})+",
    		delegate(Match m)
    		{
    			var startGroup = m.Groups["start"];
    			var propertyGroup = m.Groups["property"];
    			var formatGroup = m.Groups["format"];
    			var endGroup = m.Groups["end"];
    
    			var value = propertyGroup.Value == "0"
    				? source
    				: Eval(source, propertyGroup.Value);
    
    			if (escape && value != null)
    			{
    				value = XmlEscape(JsonEscape(value.ToString()));
    			}
    
    			values.Add(value);
    
    			var openings = startGroup.Captures.Count;
    			var closings = endGroup.Captures.Count;
    
    			return openings > closings || openings%2 == 0
    				? m.Value
    				: new string('{', openings) + (values.Count - 1) + formatGroup.Value
    				  + new string('}', closings);
    		},
    		RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
    
    	return string.Format(provider, rewrittenFormat, values.ToArray());
    }
    private static object Eval(object source, string expression)
    {
    	try
    	{
    		return DataBinder.Eval(source, expression);
    	}
    	catch (HttpException e)
    	{
    		throw new FormatException(null, e);
    	}
    }
