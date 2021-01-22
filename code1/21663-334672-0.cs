      private void checkedListBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
              if (checkedListBox1.GetItemRectangle(i).Contains(checkedListBox1.PointToClient(MousePosition)))
              {
                  switch (checkedListBox1.GetItemCheckState(i))
	              {
                      case CheckState.Checked:
                          checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                          break;
                      case CheckState.Indeterminate:
                      case CheckState.Unchecked:
                          checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                           break;
	              } 
                  
              }
			}
        }
