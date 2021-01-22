    private void SomeEventHappened(object sender, EventArgs e)
    {
        Filters.SomeValue = SomeControl.SelectedValue;
    }
    private void TimeToFetchSomeData()
    {
        GridView.DataSource = Repository.GetList(Filters);
    }
