    public partial class Test_CallBack_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tempID           = GetFormVariableOrNull(Request.Form["id"]);
            string tempOrder_ID     = GetFormVariableOrNull(Request.Form["order_id"]);
            string tempStatus       = GetFormVariableOrNull(Request.Form["status"]);
            //pending, confirming, paid, invalid, expired, canceled, refunded
    
            if (tempStatus.Equals("paid"))
            {
                //update your Purchase Order
            }
        }
    
        protected string GetFormVariableOrNull(object formvariable)
        {
            if (formvariable != null)
            {
                try
                {
                    return formvariable.ToString();
                }
                catch (Exception ex)
                {
                    /// log the exception in file or DB
                    Console.WriteLine(ex.Message);/// just for an example
                    return null;
                }
            }
            else return null;
        }
    }
