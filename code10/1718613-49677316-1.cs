    public void SelectModel(Office.IRibbonControl control, string selectedId, int SelectedItemIndex)
            {
                if (SelectedItemIndex == 0)
                {
                    MessageBox.Show("first item selected");
                }
                else if (SelectedItemIndex == 1)
                {
                    MessageBox.Show("second item selected");
                }
                else if(SelectedItemIndex == 2)
                {
                    MessageBox.Show("third item is selected");
                }
                else if (SelectedItemIndex == 3)
                {
                    MessageBox.Show("fourth item is selected");
                }
            }
