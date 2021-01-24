    private void SetDataBindings()
    {
        // You only have to set this once
        // The controls will automatically change their data when you click on another cell/row
        tbFirstName.DataBindings.Add("Text", bs, "FirstName");
        tbLastName.DataBindings.Add("Text", bs, "LastName");
        tbEmail.DataBindings.Add("Text", bs, "Email");
    }
