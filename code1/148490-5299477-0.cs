    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.UI.HtmlControls;
    using System.Windows.Forms;
    using System.IO;
    using System.Web.UI;
    
    public class HtmlToWebBrowserControlDoc
    {
    
    	// The loaded document MUST have a script similar to this
    
    	//		<script type="text/javascript" >
    	//				function appendHtml(o) {
    	//				var div = document.createElement("div");
    	//				div.innerHTML = o;
    	//				document.body.appendChild( div);
    	//				}
    	//		</script>
    
    
    	public static void InsertHtmlControl(HtmlControl c, WebBrowser wb)
    	{
    
    		// create a HtmlTextWriter;
    		StringBuilder sb = new StringBuilder();
    		StringWriter sw = new StringWriter(sb);
    		HtmlTextWriter htmlw = new HtmlTextWriter(sw);
    
    		// render the control as html
    		c.RenderControl(htmlw);
    
    
    		//invoke the script passing in the html 
    		object[] p = new object[1];
    		p[0] = (object)sb.ToString();
    		wb.Document.InvokeScript("appendHtml", p);
    
    		htmlw.Close();
    		htmlw.Dispose();
    
    		sw.Dispose();
    
    
    	}
    }
