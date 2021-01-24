        if (!DesignMode)
        {
            if (e.Index > -1)
            {
               using (StringFormat fmt = new StringFormat() 
                 { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
               {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(SystemBrushes.MenuHighlight, e.Bounds);
                    e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(), 
                                            e.Font,SystemBrushes.HighlightText, e.Bounds, fmt);
                }
                else
                {
                    e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                    e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(), 
                                            e.Font, SystemBrushes.MenuText,e.Bounds, fmt);
                }
             }
          }
        }
