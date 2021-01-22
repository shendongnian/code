        private Size _size;
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            _size = this.Size;
            if (this.FormBorderStyle == FormBorderStyle.SizableToolWindow)
            {
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            }
            this.Size = _size;
        }
