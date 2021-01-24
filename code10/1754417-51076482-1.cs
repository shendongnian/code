    public async void Button1_Click(...)
    {
        var json = await GetJsonAsync(...).ConfigureAwait(false);
        BeginInvoke(UpdateTextBox, json);
    }
    
    private void UpdateTextBox(string value)
    {
      textBox1.Text=json;
    }
