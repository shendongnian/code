    if(e.ColumnIndex == 2)
    {
        TextBox tb = e.Control as TextBox;
        if (tb != null)
        {
            tb.PasswordChar = '*';
        }
    }
