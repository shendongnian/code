    namespace PanelWizard
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void btnContinue_Click(object sender, EventArgs e)
            {
                // validate controls according to business logic
                //...
    
                // Hide and reveal panels based on the currently visible panel.
                if (wizForm1.Visible)
                {
                    wizForm1.Visible = false;
                    wizForm2.Visible = true;
                }
                else if (wizForm2.Visible)
                {
                    // and so on...
                }
            }
        }
    }
