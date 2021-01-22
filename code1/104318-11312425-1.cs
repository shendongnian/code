        protected virtual void TitlebarMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Text = string.Format("({0}, {1})", e.X, e.Y);
            }
        }
