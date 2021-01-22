     public class OfflineFactsheetBase : System.Web.UI.Page
    {
        public OfflineFactsheetBase ( )
        {
            this.Load += new EventHandler ( this.Page_Load );
            this.PreInit += new EventHandler ( this.Page_PreInit );
        }
        protected void Page_PreInit ( object sender, EventArgs e )
        {
            if ( Request.QueryString [ "data" ] != null )
            {
                this.PageData = StringCompressor.DecompressString ( Request.QueryString [ "data" ] );
                this.ExtractPageData ( );
            }
        }
        public void ExtractPageData ( )
        {
            // get stuff relevant to all pages that implement OfflineFactsheetBase 
            // ....blah...
            InternalExtractPageData ( );
        }
        // Could be abstract if the class where
        protected virtual void InternalExtractPageData ( )
        {
            // get stuff relevant to all pages that impmement OfflineFactsheetBase 
        }
    }
    public partial class GenericOfflineCommentary : OfflineFactsheetBase
    {
        public override void ExtractPageData ( )
        {
            // get stuff relevant to an OfflineCommentary page.
        }
    }
