        /// <summary>
        /// When used with the FlowLayoutPanel this will move a control up or down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="UpDown"></param>
        private void C_On_Move(object sender, int UpDown)
        {
            //If UpDown = 1 Move UP, If UpDown = 0 Move DOWN
            Control c = (Control)sender;
            // Get the controls index
            int zIndex = _flowLayoutPanel1.Controls.GetChildIndex(c);
            if (UpDown==1 && zIndex > 0)
            {
                // Move up one
                _flowLayoutPanel1.Controls.SetChildIndex(c, zIndex - 1);
            }
            if (UpDown == 0 && zIndex < _flowLayoutPanel1.Controls.Count-1)
            {
                // Move down one
                _flowLayoutPanel1.Controls.SetChildIndex(c, zIndex + 1);
            }
        }
