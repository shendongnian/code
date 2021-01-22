    private void txt3_KeyPress(object sender, KeyPressEventArgs e)
    {
        for (int h = 58; h <= 127; h++)
        {
            if (e.KeyChar == h)             //58 to 127 is alphabets tat will be         blocked
            {
                e.Handled = true;
            }
        }
        for(int k=32;k<=47;k++)
        {
            if (e.KeyChar == k)              //32 to 47 are special characters tat will 
            {                                  be blocked
                e.Handled = true;
            }
        }
    }
