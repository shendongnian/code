	Bitmap bm = new Bitmap(Side_pictureBox.Image);
	if (Tagged_Remarks_listBox.SelectedIndex == 0)
	{
		using (Graphics gr = Graphics.FromImage(bm))
		{
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
	}
	Side_pictureBox.Image = bm;
	Side_pictureBox.Invalidate();
