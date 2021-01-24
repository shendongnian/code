    private void cboCategories_TextChanged(object sender, TextChangedEventArgs e)
    {
        var cmb = sender as ComboBox;
        var viewModel = DataContext as CategoryViewModel;
        if (viewModel != null)
        {
            viewModel.Categories.Add(new Category() { Description = cmb.Text });
        }
    }
