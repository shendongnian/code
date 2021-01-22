    TextBox[] tbArray = new TextBox[]
    {
        custid,custname , field, email, phone, address
    };
    for (int i = 0; i < tbArray.Length; i++)
    {
        if (status.SelectedIndex == 1)
        {
            tbArray[i].Enabled = false;
            savecust.Enabled = false;
            deletecust.Enabled = false;
        }
        else
        {
            tbArray[i].Enabled = true;
            savecust.Enabled = true;
            deletecust.Enabled = true;
        }
    }   
*********         
