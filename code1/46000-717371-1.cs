    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(Controltest1.Items.Count > 0)
        {
            foreach (ListItem li in listbox.Items )
            {
                    if (li.Selected)
                    {
                        Controltest2.Add(li.Text, li.Value);
                    }
            }
        }
    }
