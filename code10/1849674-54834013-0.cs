    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        double saleCount = 0;
    
        Processor p = new Processor();
        // Set a flag to true and reset it to false if any checkbox is checked
        bool hasError = true;
        foreach (GridViewRow row in gvBooks.Rows)
        {
            Book objBook = new Book();
            ....    
            if (chkbx.Checked && !(string.IsNullOrEmpty(qty.Text)))
            {
                // We have at least one checkbox checked with a quantity, so no error!
                hasError = false;
                .....
            }
        }
        // Handle the label error visibility or not
        if(hasError)
        {
            lblError.Text = "* Please select a book & enter a quantity";
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
