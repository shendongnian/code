    private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
    {
        var page = tabControl.TabPages[e.Index];
        e.DrawBackground();
        e.DrawFocusRectangle();
        TextRenderer.DrawText(e.Graphics, page.Text, page.Font, e.Bounds, e.ForeColor);
        if (e.Index == tabControl.TabCount - 1)
            button6.Left = tabControl.Left + e.Bounds.Right + 3;
    }
    private void buttonAdd_Click(object sender, EventArgs e)
    {
        tabControl.TabPages.Add("new page " + tabControl.TabCount);
    }
    private void buttonRemoveLast_Click(object sender, EventArgs e)
    {
        tabControl.TabPages.RemoveAt(tabControl.TabCount - 1);
    }
