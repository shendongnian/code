	private void Side_pictureBox_Paint(object sender, PaintEventArgs e)
	{
		if (Tagged_Remarks_listBox.SelectedIndex == 0 && selectedindexreset == true)
		{
			//Side_pictureBox.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + @"pictures for app\Bus_Nearside.png";
			Side_pictureBox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"\pictures for app\Bus_Nearside.png");
			Bitmap bmforedit = new Bitmap(Side_pictureBox.Image);
	
			//MessageBox.Show("inside");
	
			using (Graphics gr = Graphics.FromImage(bmforedit))
			{
				for (int x = 0; x <= NumberingPosition.Count - 1; x++)
				{
					//MessageBox.Show(x.ToString());
					if (Numbering[x] != "1") // change accordingly
					{
						//MessageBox.Show(Numbering[x]);
						gr.SmoothingMode = SmoothingMode.AntiAlias;
						Font drawFont = new Font("Calibri (Body)", 15);
						SolidBrush drawBrush = new SolidBrush(Color.Blue);
						//MessageBox.Show(Numbering[x] + NumberingPosition[x]);
	
						gr.DrawString(Numbering[x], drawFont, drawBrush, NumberingPosition[x]);
	
						drawFont.Dispose();
						drawBrush.Dispose();
					}
				}
				// bmforedit.Save(@"C:\Users\user\Desktop\PDI_APP_EDIT_FOR_TO\PDIPROTOTYPE2\bin\Debug\pictures for app\TestImage.png");
				Side_pictureBox.Image.Dispose();
				//bmforedit.Save(@"C:\Users\user\Desktop\PDI_APP_EDIT_FOR_TO\PDIPROTOTYPE2\bin\Debug\pictures for app\TestImage1.png");
				Side_pictureBox.Image = bmforedit;
			}
	
			for (int u = 0; u <= PrevStore.Count - 1; u++)
			{
				using (Graphics g = Graphics.FromImage(bmforedit))
				{
					if (u < StartDrawCount[0] || u > StopDrawCount[0])
					{
						g.DrawLine(new Pen(Color.DarkRed, 2), PrevStore[u], NowStore[u]);
						g.SmoothingMode = SmoothingMode.AntiAlias;
					}
				}
			}
	
			bmforedit.Save(@"C:\Users\user\Desktop\PDI_APP_EDIT_FOR_TO\PDIPROTOTYPE2\bin\Debug\pictures for app\TestImage2.png");
			selectedindexreset = false;
			Side_pictureBox.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + @"pictures for app\TestImage2.png";
			Side_pictureBox.Refresh();
		}
	}
