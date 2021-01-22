        private void LV_MouseUp(object sender, MouseEventArgs e)
        {
            if (LV.FocusedItem != null)
            {
                if (LV.SelectedItems.Count == 0)
                    LV.FocusedItem.Selected = true;
            }
        }
