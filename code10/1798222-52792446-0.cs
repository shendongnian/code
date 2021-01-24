    private void BtnClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            MyDisplayArea.RegX.AddChar(btn.Text);  // ERROR!
        }
