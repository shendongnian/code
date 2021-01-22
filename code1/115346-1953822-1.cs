    private void OnButtonClick(object sender, EventArgs e)
    {
        List<String> removeMe = new List<String>();
        foreach(String x in listBox.Items)
        {
           if (String.IsNullOrEmpty(x))
           {
               removeMe.Add(x);
           }
        }
        
        foreach(String x in removeMe)
        {
              listBox.Items.Remove(x);
        }
    }
