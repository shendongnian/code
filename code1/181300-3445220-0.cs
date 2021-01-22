    using System.ComponentModel;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebControls
    {
    	[ToolboxData("<{0}:ArrayDisplayControl runat=server></{0}:ArrayDisplayControl>")]
    	public class ArrayDisplayControl : WebControl
    	{
    		public string[,] DataSource
    		{
    			get
    			{
    				return (string[,])ViewState["DataSource"];
    			}
    			set
    			{
    				ViewState["DataSource"] = value;
    			}
    		}
    
    		protected override void RenderContents(HtmlTextWriter output)
    		{
    			output.WriteBeginTag("div");
    
    			for (int i = 0; i < DataSource.GetLength(0); i++)
    			{
    				for (int j = 0; j < DataSource.GetLength(1); j++)
    				{
    					output.WriteFullBeginTag("p");
    					output.Write(DataSource[i, j]);
    					output.WriteEndTag("p");
    				}
    			}
    
    			output.WriteEndTag("div");
    		}
    	}
    }
