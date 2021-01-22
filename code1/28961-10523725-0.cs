    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {            
    	Point p = this.tabControl1.PointToClient(Cursor.Position);
    	for (int i = 0; i < this.tabControl1.TabCount; i++)
    	{
    		Rectangle r = this.tabControl1.GetTabRect(i);
    		if (r.Contains(p))
    		{
    			this.tabControl1.SelectedIndex = i; // i is the index of tab under cursor
    			return;
    		}
    	}
    	e.Cancel = true;
    }
