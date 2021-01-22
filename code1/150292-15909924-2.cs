    public class BaseReport : System.Web.UI.Page
    {
    	protected override void OnLoad(EventArgs e)
    	{
    		if (!IsPostBack) {
    			for (var i = 0; i < Session.Count; i++) {
    				var sv = Session[i];
    				// if this session variable contains a Crystal Report, destroy it
    				if (sv is ReportClass) {
    					sv = null;
    				}
    			}
    			
    			base.OnLoad(e);
    		}
    	}
    }
