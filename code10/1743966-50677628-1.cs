     public partial class TestUserControl : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                //Manually Add event handler
                grdControlsGrid.RowDataBound += GrdControlsGrid_RowDataBound;
            }
    
            private void GrdControlsGrid_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                //Manually bound event
            }
    
            protected void grdControlsGrid_OnRowDataBound(object sender, GridViewRowEventArgs e)
            {
                //Auto wired event
            }
        }
