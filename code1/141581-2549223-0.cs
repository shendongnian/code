    using System.Web.UI.WebControls.Adapters;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace ExampleCode
    {
    	public class ImageAdapter : WebControlAdapter
    	{
            private bool UseCdn
            {
                get { return true; } // Get value from config or anywhere else
            }
    		protected override void OnPreRender(EventArgs e)
    		{
    			base.OnPreRender(e);
    
    			Image image = (Image)Control;
                if (UseCdn)
                {
                    // If using relative urls for images may need to handle ~
                    image.ImageUrl = String.Format("{0}/{1}", "CDN URL", image.ImageUrl);
                }
             }
          }
     }
