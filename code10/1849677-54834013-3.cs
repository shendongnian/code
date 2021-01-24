    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        double saleCount = 0;
    
        Processor p = new Processor();
        // Prepare a list of errors 
        List<string> errors = new List<strig>();
        foreach (GridViewRow row in gvBooks.Rows)
        {
            Book objBook = new Book();
            ....    
            if (chkbx.Checked)
            {
               
               // Probably it is better to check here also the quantity value
               // not just for text in the textbox (it could be anything)
               if(Int32.TryParse(qty.Text, out int quantity) && quantity > 0)
               {
                    // We have at least one checkbox checked with a quantity, so no error!
                   .....
               }
               else
               {
                  // We don't have a quantity, add book title to error list....
                  errors.Add($"Book {title} has no quantity!");
               }
            }
        }
        // Handle the errors, if any
        if(errors.Count > 0)
        {
            lblError.Text = string.Join("<br/>, errors);
            lblError.Visible = true;
        }
        else
        {
            lblError.Visible = false;
            gvOrder.DataSource = orderList;
            gvOrder.DataBind();
    
            gvOrder.Columns[0].FooterText = "Totals";
            gvOrder.Columns[5].FooterText = saleCount.ToString();
            gvOrder.Columns[6].FooterText = orderTotal.ToString("C2");
        }
    }
