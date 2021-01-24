	if (Tagged_Remarks_listBox.SelectedIndex == 0)
	{
		Graphics gr = e.Graphics;
		gr.SmoothingMode = SmoothingMode.AntiAlias;
		Font drawFont = new Font("Calibri (Body)", 15);
		SolidBrush drawBrush = new SolidBrush(Color.Blue);
		for (int x = 1; x <= NumberingPosition.Count - 1; x++)
		{       
			//MessageBox.Show(Numbering[u] + NumberingPosition[u]);
			gr.DrawString(Numbering[x], drawFont, drawBrush, NumberingPosition[x]);
		}
		drawFont.Dispose();
		drawBrush.Dispose();
	}
