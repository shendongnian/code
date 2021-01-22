    public void Button_Click(object sender, EventArgs e)
    {
      Oval.ContextMenu =
        new ContextMenu { ItemsSource = new[] { "Apples", "Bananas" } };
    }
