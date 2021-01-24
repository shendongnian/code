    if( listBox1.Items.Count <= 3 ){
        listBox1.Items.Add(Item1.Text);
        Item1.Focus();
        Item1.Text = String.Empty;
    }else{
        messagebox.Show("You've reached the number of items")
    }
