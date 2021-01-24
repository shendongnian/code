        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0  )
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                string imageFilePath = @Items[e.Index].ToString();;
                int width = 40;
                int height = 20;
                Image img = Image.FromFile(imageFilePath);
                e.Graphics.DrawImage(img, 0, e.Bounds.Top + 2, width, height);
                e.Graphics.DrawString(imageFilePath, e.Font, new
                        SolidBrush(e.ForeColor), e.Bounds.Left + width, e.Bounds.Top + 2);
                base.OnDrawItem(e);
            }
        }
    }
