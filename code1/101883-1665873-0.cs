    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        int index = e.Index;
        Graphics g = e.Graphics;
        foreach (int selectedIndex in this.listBox1.SelectedIndices)
        {
            if (index == selectedIndex)
            {
                // Draw the new background colour
                e.DrawBackground();
                g.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
            }
        }
        // Get the item details
        Font font = listBox1.Font;
        Color colour = listBox1.ForeColor;
        string text = listBox1.Items[index].ToString();
        // Print the text
        g.DrawString(text, font, new SolidBrush(Color.Black), (float)e.Bounds.X, (float)e.Bounds.Y);
        e.DrawFocusRectangle();
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        listBox1.Invalidate();
    }
