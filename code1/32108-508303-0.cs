    foreach(Control c in this.Controls)
    {
        if(c.Name.StartsWith("lblTableValue"))
        {
            c.DataBindings.Clear();
        }
    }
