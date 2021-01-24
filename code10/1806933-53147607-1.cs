    public partial class print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
                DateTime date = DateTime.Now;
                lblDateIssue.Text = " Date Issue:" + date.ToShortDateString();
    
                var dueDate = date.AddDays(14);
                lblDueDate.Text = " DueDate:" + dueDate.ToShortDateString();
    
                
    
    
            lblItem1Ttl.Text += "$" + (double)(Session["subTotal1"]);
            lblItem2Ttl.Text += "$" + (double)(Session["subTotal2"]);
            lblItem3Ttl.Text += "$" + (double)(Session["subTotal3"]);
    
            double total = ((double)(Session["subTotal1"]) + ((double)(Session["subTotal2"])) + (double)(Session["subTotal3"]));
    
            lblTotalAmount.Text += "$" + total;
        }
    
    
    }
