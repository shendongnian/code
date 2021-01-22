    /// <summary>
    /// Modified XML writer that writes (almost) no namespaces out with pretty formatting
    /// </summary>
    /// <seealso cref="http://blogs.msdn.com/b/kaevans/archive/2004/08/02/206432.aspx"/>
    public class XmlNoNamespaceWriter : XmlTextWriter
    {
    	private bool _SkipAttribute = false;
    	private int _EncounteredNamespaceCount = 0;
    
    	public XmlNoNamespaceWriter(TextWriter writer)
    		: base(writer)
    	{
    		this.Formatting = System.Xml.Formatting.Indented;
    	}
    
    	public override void WriteStartElement(string prefix, string localName, string ns)
    	{
    		base.WriteStartElement(null, localName, null);
    	}
    
    	public override void WriteStartAttribute(string prefix, string localName, string ns)
    	{
    		//If the prefix or localname are "xmlns", don't write it.
    		//HOWEVER... if the 1st element (root?) has a namespace we will write it.
    		if ((prefix.CompareTo("xmlns") == 0
    				|| localName.CompareTo("xmlns") == 0)
    			&& _EncounteredNamespaceCount++ > 0)
    		{
    			_SkipAttribute = true;
    		}
    		else
    		{
    			base.WriteStartAttribute(null, localName, null);
    		}
    	}
    
    	public override void WriteString(string text)
    	{
    		//If we are writing an attribute, the text for the xmlns
    		//or xmlns:prefix declaration would occur here.  Skip
    		//it if this is the case.
    		if (!_SkipAttribute)
    		{
    			base.WriteString(text);
    		}
    	}
    
    	public override void WriteEndAttribute()
    	{
    		//If we skipped the WriteStartAttribute call, we have to
    		//skip the WriteEndAttribute call as well or else the XmlWriter
    		//will have an invalid state.
    		if (!_SkipAttribute)
    		{
    			base.WriteEndAttribute();
    		}
    		//reset the boolean for the next attribute.
    		_SkipAttribute = false;
    	}
    
    	public override void WriteQualifiedName(string localName, string ns)
    	{
    		//Always write the qualified name using only the
    		//localname.
    		base.WriteQualifiedName(localName, null);
    	}
    }
