    int yourInteger;
    string newItem;
    newItem = textBox1.Text.Trim();
    
    if(newItem != string.Empty)
    {
       if ( newItem == Convert.ToInt32(textBox1.Text))
       {
          listBox1.Items.Add(newItem);
       }
    }
