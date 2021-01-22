    void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var item = ListView.SelectedItem as Track;
        if (item != null)
        {
          MessageBox.Show(item.ToString()+" Double Click handled!");
        }
    }
