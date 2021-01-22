    public class CustomBase : System.Web.UI.Page  
    {    
    	protected override void Render( System.Web.UI.HtmlTextWriter textWriter ) 
    	{
    	    using (System.IO.StringWriter stringWriter = new System.IO.StringWriter())
    	    {
    		     using (HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter))
    		     {    
    		         LiteralControl header =new LiteralControl();
    		         header.Text = RenderHeader(); // implement HTML HEAD BODY...etc
    
    		         LiteralControl footer = new LiteralControl();
    		         footer.Text = RenderFooter(); // implement CLOSE BODY HTML...etc
    		    
    		         this.Controls.AddAt(0, header); //top
    		         this.Controls.Add(footer); //bottom
    		    
    		         base.Render(htmlWriter); 
    		     }
    	    }
    
    	    textWriter.Write(stringWriter.ToString());
    	}       
    
    }
