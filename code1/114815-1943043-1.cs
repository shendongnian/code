    public void GetTextBoxValuesFromListView()
    {
        Textbox tb = null;
        ListViewItem Item = null;
        foreach (ListViewDataItem item in CouncilListView.Items)
        {
            Item = item;
            tb = ((TextBox) (Item.FindControl("EmailTextBox")));
            if (tb.Text != null)
            {
                //Do something
            }
        }
    }
