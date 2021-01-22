    protected void btnRemove_Click(object sender, EventArgs e)
    {
        {
            for (int i = 0; i < lstAvailableColors.Items.Count; i++)
            { 
                if(lstAvailableColors.Items[i].Selected)
                    lstAvailableColors.Items.RemoveAt(i);
            }
        }
    }
