        private void lvBase_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            for (int i = 0; i < lvBase.Items.Count; i++)
            {
                lvBase.Items[i].Checked = e.Item.Checked;
            }
        }
