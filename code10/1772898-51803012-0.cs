    protected void Delete_Click(object sender, EventArgs e)
    {
        var sendr = sender as RadioButton;
        if (sendr != null)
        {
            var clickedItem = sendr.DataContext as YourModel;
            if (clickedItem != null)
            {
                Label1.Text = clickedItem.Name;
            }
        }
    }
