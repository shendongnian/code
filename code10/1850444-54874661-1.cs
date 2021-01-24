    CartItem item;
    // .. fill data
    if(int.TryParse(textBox9.Text, out int x))
    {
        item.Quantity = x;
    }
    textBox21.Text = item.Cost.ToString("c");
