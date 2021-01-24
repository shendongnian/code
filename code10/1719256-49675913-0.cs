        private void systemRecordTabControl_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground(); //<-- Redraw background       
            e.Graphics.DrawImage(Properties.Resources.icon, e.Bounds.Right - 15, e.Bounds.Top + 3, 11, 11);
            e.Graphics.DrawString(systemRecordTabControl.TabPages[e.Index].Text, new Font("Arial", 12, FontStyle.Underline), Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }
