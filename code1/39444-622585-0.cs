    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    
    
    /// <summary>
    /// A COM interface is needed because .NET does not provide a way
    /// to set the properties of a HTML script element.
    /// This class negates the need to refrence mshtml in its entirety
    /// </summary>
    [ComImport, Guid("3050F536-98B5-11CF-BB82-00AA00BDCE0B"),
    InterfaceType((short)2),
    TypeLibType((short)0x4112)]
    public interface IHTMLScriptElement
    {
    	/// <summary>
    	/// Sets the text property
    	/// </summary>
    	[DispId(1006)]
    	string Text
    	{
    		[param: MarshalAs(UnmanagedType.BStr)]
    		[PreserveSig,
    		MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
    		DispId(-2147417085)]
    		set;
    	}
    
    	/// <summary>
    	/// Sets the src property
    	/// </summary>
    	[DispId(1001)]
    	string Src
    	{
    		[param: MarshalAs(UnmanagedType.BStr)]
    		[PreserveSig,
    		MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
    		DispId(-1001)]
    		set;
    	}
    }
    
    // Inject script element
    public void InjectJavascript(string javascript, HTMLDocument doc)
    {
    	if (doc != null)
    	{
    		try
    		{
                        // find the opening head tag
    			HtmlElement head =  doc.GetElementsByTagName("head")[0];
                        // create the script element
    			HtmlElement script =  doc.CreateElement("script");
                        // set it to javascirpt
    			script.SetAttribute("type", "text/javascript");
                        // cast the element to our custom interface
    			IHTMLScriptElement element = (IHTMLScriptElement)script.DomElement;
                        // add the script code to the element
    			element.Text = "/* <![CDATA[ */ " + javascript + " /* ]]> */";
                        // add the element to the document
    			head.AppendChild(script);
    		}
    		catch (Exception e)
    		{
    			MessageBox.show(e.message);
    		}
    	}
    }
   
