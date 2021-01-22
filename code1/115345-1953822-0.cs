    private void OnButtonClick(object sender, EventArgs e)
    {
        foreach(String x in listBox.Items)
        {
           if (String.IsNullOrEmpty(x))
           {
               listBox.Items.Remove(x);
           }
        }
    }
