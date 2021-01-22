    private void ListBoxOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
    {
            var listbox = sender as ListBox;
            if (listbox == null) return;
            // set tool tip for listbox
            var strTip = string.Empty;
            var index = listbox.IndexFromPoint(mouseEventArgs.Location);
            if ((index >= 0) && (index < listbox.Items.Count))
                strTip = listbox.Items[index].ToString();
            if (_toolTip.GetToolTip(listbox) != strTip)
            {
                _toolTip.SetToolTip(listbox, strTip);
            }
    }
