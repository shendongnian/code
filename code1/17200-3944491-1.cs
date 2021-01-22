    Control c = this.FindControl("tbName");
    if (c != null)
    {
        // Do something with c
        customer.Name = ((TextBox)c).Text;
    }
