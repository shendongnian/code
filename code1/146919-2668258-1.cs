    public void Button_Click(object sender, EventArgs e)
    {
      var menu = (ContextMenu)Resources["Vegetables"];
      menu.Items.Add(new MenuItem { Header = "Carrots" });
    }
