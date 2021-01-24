        {
            Brush brush = null;
            ComboBox combo = (ComboBox)sender;
            if (TRUE)
            {
                //SELECT
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                brush = ((e.State & DrawItemState.Selected) > 0) ? SystemBrushes.HotTrack : SystemBrushes.ControlText;
                e.Graphics.DrawString(_comboItems[e.Index].Text, combo.Font, brush, e.Bounds);
            }
            else
            {
                e.DrawBackground();
                e.Graphics.FillRectangle(Brushes.DarkGray, e.Bounds);
                brush = ((e.State & DrawItemState.Selected) > 0) ? SystemBrushes.HighlightText : SystemBrushes.ControlText;
                e.Graphics.DrawString(_comboItems[e.Index].Text, combo.Font, brush, e.Bounds);
                e.DrawFocusRectangle();
            }
        }
