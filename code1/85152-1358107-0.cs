     this.textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
     this.textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox t = sender as TextBox;
        if (t != null)
        {
            //say you want to do a search when user types 3 or more chars
            if (t.Text.Length >= 3)
            {
                //SuggestStrings will have the logic to return array of strings either from cache/db
                string[] arr = SuggestStrings(t.Text);
    
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(arr);
    
                this.textBox1.AutoCompleteCustomSource = collection;
            }
        }
    }
