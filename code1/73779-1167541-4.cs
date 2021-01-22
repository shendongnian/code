    protected void ValidPage_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            args.IsValid = (!string.IsNullOrEmpty(this.txtVendnum.Text) || this.DropDownList1.SelectedIndex != 0);
        }
        catch (Exception e)
        {
            ((CustomValidator)source).ErrorMessage = "You must Choose a Vendor";
            args.IsValid = false;
        } 
    }
    protected void Button_Click(object sender, EventArgs e)
    {
         if (Page.IsValid)
         { 
             //do work
         }
    }
