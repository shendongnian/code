    using System.Xml;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main( string[] args )
    		{
    			var doc = new XmlDocument();
    			// Load xml document.
    			TraverseNodes( doc.ChildNodes );
    		}
    
    		private static void TraverseNodes( XmlNodeList nodes )
    		{
    			foreach( XmlNode node in nodes )
    			{
    				// Do something with the node.
    				TraverseNodes( node.ChildNodes );
    			}
    		}
    	}
    }
