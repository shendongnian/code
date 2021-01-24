    Form1 form1 = new Form1();
    foreach (Control c in form1.Controls)
    {
        if (c.Tag != null && c.Tag.Equals("FromDesigner"))
        {
        }
    }
