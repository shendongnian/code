    private void button1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(textBox1.Text))
        {
            webBrowser1.Navigate(textBox1.Text);
        }
    }
    private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
    {
        if (textBox1.Text != e.Url.ToString())
        {
            textBox1.Text = e.Url.ToString();
        }
    }
