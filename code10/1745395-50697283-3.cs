    private void TextBoxUpdater(int num)
    {
        if (this.InvokeRequired)
        {
            //if current call is form other than UI thread invoke to UI thread
            this.BeginInvoke(new Action(() => TextBoxUpdater(num)));
        }
        else
        {
            //If it is UI thread (meaning this call is coming from If part of this method)
            //and as it is UI thread now, we can update textbox's text
            txtBox1.Text = num.ToString();
            txtBox2.Text = num.ToString();
            txtBox3.Text = num.ToString();
            if (txtBox1.Text.Substring(1) == "1")
            {
            }
        }
    }
