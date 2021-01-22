        private void Resize_Form(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (MousePosition.X >= this.Location.X + formWidth - 10))
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeWE;
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_RIGHT, 0);
                formWidth = this.Width;
            }
        }
