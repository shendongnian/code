    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.State == DrawItemState.Focus)
                e.DrawFocusRectangle();
            int index = e.Index;
            if (index < 0 || index >= listBox1.Items.Count) return;
            var item = listBox1.Items[index];
            string text = (item == null) ? "(null)" : item.ToString();
            int newHE = (int)(e.Graphics.MeasureString(text, e.Font).Width + 2);
            if (listBox1.HorizontalExtent < newHE)
            {
                listBox1.HorizontalExtent = newHE;
            }
            using (var brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                e.Graphics.DrawString(text, e.Font, brush, 0f, e.Bounds.Top + 3); //I do +3 because I wanted to shimmy the text down a bit from the top
            }
        }
