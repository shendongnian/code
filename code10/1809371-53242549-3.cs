        private void bNew_Click(object sender, EventArgs e)
            {
                score link = new score();
                link.ShowDialog();//Note that you wont be able to access form1.
                SudentBox.Items.Clear();
    //You can now get the name
    string _nameResult=link.Name;
    NameTextbox.Text=_nameResult;
            }
