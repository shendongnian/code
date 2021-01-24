     private void gridView_SelectionChanged(object sender, EventArgs e)
            {
                if (gridView.SelectedRows.Count > 0)
                {
                    int age = Convert.ToInt32(gridView.SelectedRows[0].Cells["Age"].Value.ToString());
                    string name = gridView.SelectedRows[0].Cells["Name"].Value.ToString();
                    txtName.Text = name;
                    ddlAgeList.Items.Insert(0,new ListItem(age.ToString()));// 0 is index of item
                }
            }
