        private void MouseLeftGroupBox(object sender, EventArgs e)
        {
            //Pass in the location and size of your groupbox, also the cursors position on your form
            if (!IsAboveGroupBox(groupBox1, PointToClient(Cursor.Position)))
            {
                //Add controls to be hidden when leaving the groupbox
                button1.Visible = false;
            }
        }
