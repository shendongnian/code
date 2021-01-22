    private void PrintButton_Click(object sender, EventArgs e)
    {
    	FlowLayoutPanel flp = TheBuildFlowLayoutPanel;
    	List<Bitmap> printPics = new List<Bitmap>();
    	int printLastY = 100;
    	flp.VerticalScroll.Value = 0;
    	while (flp.DisplayRectangle.Y < printLastY) // DisplayRect.Y becomes successively more negative
    	{
    		Bitmap bmp = new Bitmap(flp.Width, flp.Bounds.Height);
    		printPics.Add(bmp);
    		flp.DrawToBitmap(bmp, flp.ClientRectangle);
    		printLastY = flp.DisplayRectangle.Y;
    		flp.VerticalScroll.Value = Math.Min(flp.VerticalScroll.Maximum, flp.VerticalScroll.Value + flp.Height);
    	}
    
    	flp.VerticalScroll.Value = 0;
    	for (int i = 0; i < printPics.Count; i++)
    	{
    		printPics[i].Save("C:\\Temp" + i.ToString() + ".bmp");
    	}
    }
