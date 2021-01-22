        private void lstDrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox lst = (ListBox)sender;
            e.DrawBackground();
            e.DrawFocusRectangle();
            
            DrawItemState st = DrawItemState.Selected ^ DrawItemState.Focus;
            Color col = ((e.State & st) == st) ? Color.Yellow : lst.BackColor;
            e.Graphics.DrawRectangle(new Pen(col), e.Bounds);
            e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);
            if (e.Index >= 0)
            {
                e.Graphics.DrawString(lst.Items[e.Index].ToString(), e.Font, new SolidBrush(lst.ForeColor), e.Bounds, StringFormat.GenericDefault);
            }
        }
