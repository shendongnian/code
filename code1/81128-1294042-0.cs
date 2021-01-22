    private void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
        string[] parts = e.Node.Text.Split(' ');
        if (parts.Length > 1)
        {
            string first = parts[0];
            string rest = " " + string.Join(" ", parts, 1, parts.Length - 1);
            float firstWidth;
            using (Font boldFont = new Font(e.Node.TreeView.Font, FontStyle.Bold))
            {
                firstWidth = e.Graphics.MeasureString(first, boldFont).Width;
                e.Graphics.DrawString(first, boldFont, SystemBrushes.WindowText, e.Bounds);
            }
            e.Graphics.DrawString(rest, e.Node.TreeView.Font, SystemBrushes.WindowText, e.Bounds.Left + firstWidth, e.Bounds.Top);
        }
       else
       {
           e.DrawDefault = true;
       }
    }
