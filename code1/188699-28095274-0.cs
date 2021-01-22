     // add zero before point
        public void addzerobefore(object sender, KeyPressEventArgs e)
        {
            TextBox add0txtbx = sender as TextBox;
            if ((add0txtbx.Text.Trim()).StartsWith("."))
            {
                add0txtbx.Text = "0"+add0txtbx.Text;
                add0txtbx.Select(add0txtbx.Text.Length, 0);
            }
        }
