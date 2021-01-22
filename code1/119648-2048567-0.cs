    private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (!clicked)
            {
                clicked = true;
                state = CheckBoxState.CheckedPressed;  
                foreach (ListViewItem item in listView.Items)
                {
                    item.Checked = true;
                }
                Invalidate();
            }
            else
            {
                clicked = false;
                state = CheckBoxState.UncheckedNormal;
                Invalidate();
                foreach (ListViewItem item in listView.Items)
                {
                    item.Checked = false;
                }
            }           
        }
