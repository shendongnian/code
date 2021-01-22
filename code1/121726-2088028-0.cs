        public void addUpdateNotification(Control start)
        {
            foreach (Control c in start.Controls)
            {
                if (c is TextBox)
                {
                    var text = c as TextBox;
                    c.TextChanged += notifyChanged;
                }
                
                addUpdateNotification(c);
            }
        }
        public void notifyChanged(Object sender, EventArgs args)
        {
            UpdateTextBox.Text = "*";
        }
