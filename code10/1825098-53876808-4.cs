    private void CustomerSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
    {
        MySpinner spinner = sender as MySpinner;
        int SelectedSpinnerCustomer = spinner.Id;
        int age = spinner.Age;
        string name = spinner.Name;
        string gender = spinner.Gender;
    }
