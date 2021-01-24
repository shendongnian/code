        private void MouseLeftGroupBox(object sender, EventArgs e)
        {
            if (!IsAboveGroupBox(sender as GroupBox))
            {
                //Add controls to be hidden when leaving the groupbox
                button1.Visible = false;
            }
        }
