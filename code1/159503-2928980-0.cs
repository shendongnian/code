            protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawString("Normal style", this.Font, Brushes.Black, 50, 50);
            e.Graphics.TextRenderingHint =
                 System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.DrawString("ClearType style", this.Font, Brushes.Black, 50, 100);
        }
