        if (!DesignMode)
        {
            if (e.Index > -1)
            {
                StringFormat fmt = new StringFormat() 
                 { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.Blue, e.Bounds);
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font,
                       Brushes.White, e.Bounds, fmt);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font,
                       Brushes.Black,e.Bounds, fmt);
                }
            }
        }
