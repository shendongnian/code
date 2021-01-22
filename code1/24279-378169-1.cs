    this.Grid.AlternatingRowBackground = null; 
    private void Grid_PreparingRow(object sender, DataGridRowEventArgs e)
    {
        CheesyClass c = e.Row.DataContext as CheesyClass;
        if (c != null && c.Cheese == "cheddar")
        {
           e.Row.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 125, 125));
        }
    }
