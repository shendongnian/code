    public void RefreshMyAwesomeGrid()
    {
        using (DatabaseContext db = new DatabaseContext())
        {
            customersBindingSource.DataSource = db.Customers.ToList();
        }
    }
    ...
    MyUserControl.BringToFront();
    RefreshMyAwesomeGrid();
