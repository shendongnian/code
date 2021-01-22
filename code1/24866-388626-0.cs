    public class xsltmanager
    {
    	/* constructor (singleton) which defines a file watcher for *.xsl in the path of your choice */
    
        //just a mutex for thread safety
        private object Mutex = new object();
        //caching XslCompiledTransforms
    	private Dictionary<string, XslCompiledTransform> cTransforms = new Dictionary<string, XslCompiledTransform>();
    
    	public XslCompiledTransform fetch(string identifier)
    	{  		
    		if (!this.cTransforms.ContainsKey(identifier))
    		{
    			lock (this.Mutex)
    			{
    				if (!this.cTransforms.ContainsKey(identifier))
    				{
    					XslCompiledTransform xslDoc = new XslCompiledTransform();
    					xslDoc.Load(/* file path based on identifier */);
    
    					this.cTransforms.Add(identifier, xslDoc);
    				}
    			}
    		}
    		return this.cTransforms[identifier];
    	}
    
    	/* other util xslt methods - namespace wash, doc merge, whatever */
    }
    
    public class myPage : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		//get source data
    		XPathDocument xPathDoc = myGetXMLMethod();
    
    		//transform params
    		XsltArgumentList oArgs = new XsltArgumentList();
    
    		/* add params as required */
    
    		//fetching and executing the transform directly to the Response here
    		xsltmanager.instance.get(@"foo\bar\baz").Transform(xPathDoc, oArgs, Response.OutputStream);
    	}
    }
