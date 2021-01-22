    public void Button_Click(object sender, EventArgs e)
    {
      Resources["Vegetables"] =
        new ContextMenu { ItemsSource = new[] {"Zucchini", "Tomatoes"} };
    }
