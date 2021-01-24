    private void TextBoxUpdater(int num)
    {
        //here i m checking, if it is from different thread then UI thread
        //if yes then Invoke is used, 
        //      so it will call the same method but in UI thread
        if(this.InvokeRequired)
        {
            txtBox1.BeginInvoke(new Action(() => TextBoxUpdater(num)));
            txtBox2.BeginInvoke(new Action(() => TextBoxUpdater(num)));
            txtBox3.BeginInvoke(new Action(() => TextBoxUpdater(num)));
        }
        else
        {
            //If it is UI thread (meaning this call is coming from If part of this method)
            //and as it is UI thread now, we can update textbox's text
            txtBox1.Text = num.ToString();
            txtBox2.Text = num.ToString();
            txtBox3.Text = num.ToString();
            
            //perform this logic too insdie of else block
            if (txtBox1.Text.Substring(1) == "1")
            {
            }
        }
    }
