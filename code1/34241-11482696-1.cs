	System.Windows.Forms.Button Btn = new System.Windows.Forms.Button();
	if (flag == true)
	{
		for (int i = 0; i < node; i++)
		{
			Btn = new Button();
			Btn.Height = 25;
			Btn.Width =30;
			Btn.ForeColor = Color.Blue;
			Btn.BackColor = Color.Brown;                 
			Btn.AutoSize = false;
			x = rd.Next(130, 800);
			y = rd.Next(130, 500);
			Btn.Location = new Point(x, y);
			Console.WriteLine(x + "," + y);
			Btn.Text = "U" + i.ToString();
			Btn.Name = "U" + i.ToString();
			m_streamWriter.WriteLine("{0} {1} {2}",
			                         Btn.Name.ToString(),
			                         Btn.Location.X.ToString(),
			                         Btn.Location.Y.ToString());
			Btn.Click += new System.EventHandler(this.Btn_Click);
			this.Controls.Add(Btn);                    
		}
		flag = false;
		m_streamWriter.Dispose();
		startConvert();
		get_combo1();                          
	}
