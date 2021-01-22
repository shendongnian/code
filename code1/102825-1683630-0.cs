	private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
	{
		Font font = new Font("Arial", 10f);
		Graphics g = e.Graphics;
		Pen rectPen = new Pen(Color.Black, 2f);
		Brush brush = Brushes.Black;
		// find widest width of items
		for (int i=0; i<listBox1.Items.Count; i++)
			if(maxItemWidth < (int)g.MeasureString(listBox1.Items[i].ToString(), font).Width)
				maxItemWidth = (int)g.MeasureString(listBox1.Items[i].ToString(), font).Width;
		// starting positions:
		int itemHeight = (int)g.MeasureString("TEST", font).Height + 5;
		int maxItemWidth = 0;
		int xpos = 200;
		int ypos = 200;
		// print
		for (int i = 0; i < listBox1.Items.Count; i++)
		{
			g.DrawRectangle(rectPen, xpos, ypos, maxItemWidth, itemHeight );
			g.DrawString(listBox1.Items[i].ToString(), font, brush, xpos, ypos);
			ypos += itemHeight;
		}
		e.HasMorePages = false;
	}
