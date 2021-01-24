    public partial class invoice : System.Web.UI.Page
    {
      
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Session["subTotal1"] = 0.0;
                Session["subTotal2"] = 0.0;
                Session["subTotal3"] = 0.0;
    
            }
    
        }
    
        public void btnSubmit_Click(object sender, EventArgs e)
        {
    
            try
            {
                int qty1 = Int32.Parse(txtQty1.Text);
                double price1 = double.Parse(txtPrice1.Text);
                Session["subTotal1"] = (double)Session["subTotal1"] + (price1 * qty1);
            }
            catch
            {
                txtQty1.Text = "";
                txtPrice1.Text = "";
            }
    
            try
            { 
            int qty2 = Int32.Parse(txtQty2.Text);       
            double price2 = double.Parse(txtPrice2.Text);
            Session["subTotal2"] = (double)Session["subTotal2"] + (price2 * qty2);
            }
            catch
            {
    
            }
    
            try
            {
                int qty3 = Int32.Parse(txtQty3.Text);
                double price3 = double.Parse(txtPrice3.Text);
                Session["subTotal3"] = (double)Session["subTotal3"] + (price3 * qty3);
    
            }
            catch
            {
                txtQty3.Text = "";
                txtPrice3.Text = "";
    
            }
            
            Server.Transfer("print.aspx", true);
        }
    }
