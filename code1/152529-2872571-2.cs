            if (mybitmap == null)
            {
                return;
            }
            using (Pen pen = new Pen(Color.Red, 2))
            {
                using (Graphics g = Graphics.FromImage(mybitmap))
                {
                e.Graphics.DrawRectangle(pen, rect);
                    
                 if (label1.TextAlign == ContentAlignment.TopLeft)
                    {
                        e.Graphics.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), label1.Bounds); 
                        g.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), label1.Bounds);
