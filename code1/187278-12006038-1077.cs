	// using System.Drawing;
	using (var image=new Bitmap(100, 100))
	using (var gr = Graphics.FromImage(image))
	{
		gr.FillRectangle(Brushes.Gold, 0, 0, 100, 100);
		gr.DrawEllipse(Pens.Blue, 5, 5, 90, 90);
		gr.Save();
		image.Dump();
	}
