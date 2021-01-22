    private void SetDDLs(DropDownList d,string val)
        {
            ListItem li;
            for (int i = 0; i < d.Items.Count; i++)
            {
                li = d.Items[i];
                if (li.Value == val)
                {
                    d.SelectedIndex = i;
                    break;
                }
            }
        }
