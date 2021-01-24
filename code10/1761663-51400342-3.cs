    public void Fill_Combo()
    {
        var customers = GetCustomers();
        var ids = customers.Select(x => x.ID.ToString());
        cmbBoxId.Items.AddRange(ids.ToArray());
    }
