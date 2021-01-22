        void ControlCheckBoxList(int selected, bool val)
        {
            switch (selected)
            {
                case 1:
                case 2:
                case 3:
                    checkedListBox1.SetItemChecked(5, !val);
                    break;
                case 6:
                    checkedListBox1.SetItemChecked(1, true);
                    break;
                default:
                    checkedListBox1.ClearSelected();
                    break;
            }
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ControlCheckBoxList(e.Index, e.NewValue == CheckState.Checked ? true : false);
        }
