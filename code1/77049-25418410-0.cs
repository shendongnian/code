    private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (Makeselection)
            {
                try
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        Cursor = Cursors.Cross;
                        cropX = e.X;
                        cropY = e.Y;
                        cropPen = new Pen(Color.Crimson, 1);
                        cropPen.DashStyle = DashStyle.Solid;
                    }
                    picBox.Refresh();
                }
                catch (Exception ex)
                {
                }
            }
        }
        private void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Makeselection)
            {
                Cursor = Cursors.Default;
            }
        }
        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (Makeselection)
            {
                picBox.Cursor = Cursors.Cross;
                try
                {
                    if (picBox.Image == null)
                        return;
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        picBox.Refresh();
                        cropWidth = e.X - cropX;
                        cropHeight = e.Y - cropY;
                        picBox.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        private void picBox_MouseLeave(object sender, EventArgs e)
        {
            tabControl.Focus();
        }
        private void picBox_MouseEnter(object sender, EventArgs e)
        {
            picBox.Focus();
        }
