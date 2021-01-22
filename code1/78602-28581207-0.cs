    void DrawTheBar(int[] Values, Panel p)
		{			    		
    		//configuration of the bar chart
    		int barWidth = 20; //Width of the bar
    		int barSpace = 5; //Space between each bars.
    		int BCS = 5; //Background cell size
    		float fontSize = 8;
    		string fontFamily = "Arial";		
    		
    		Color bgColor = Color.White;
    		Brush fillColor = Brushes.CadetBlue;
    		Color borderColor = Color.Black;
    		Color bgCellColor = Color.Silver;
    		Brush textColor = Brushes.Black;
    		
    		//do some magic here...
    		p.BackColor = bgColor; //set the bg color on panel
    		Graphics g = p.CreateGraphics();
    		g.Clear(bgColor); //cleans up the previously draw pixels
    		int Xpos = barSpace; //initial position
    		int panelHeight = panel1.Height-1; //fix panel height for drawing border 
    		
    		//Drawing rectangles for background.
    		for(int c = 0; c < Convert.ToInt16(panel1.Width / BCS); c++)
    		{
    			for(int r = 0; r < Convert.ToInt16(panel1.Height / BCS); r++)
    			{
    				g.DrawRectangle(new Pen(bgCellColor), c * BCS, r * BCS, BCS, BCS);
    			}
    		}
    		//Drawing the bars
    		for(int i = 0; i < Values.Length; i++)
    		{
    			//Drawing a filled rectangle. X = Xpos; Y = ((panel Height - 1) - Actual value); Width = barWidth, Height = as value define it
    			g.FillRectangle(fillColor, Xpos, (panelHeight - Values[i]), barWidth, Values[i]);
    			//Draw a rectangle around the previously created bar.
    			g.DrawRectangle(new Pen(borderColor), Xpos, (panelHeight - Values[i]), barWidth, Values[i]);
    			//Draw values over each bar.
    			g.DrawString(Values[i].ToString(), new Font(fontFamily, fontSize), textColor, (Xpos + 2), (panelHeight - Values[i]) - (fontSize + barSpace));
    			
    			//calculate the next X point for the next bar.
    			Xpos += (barWidth + barSpace);
    		}
    		
    		//here you will be happy with the results. :)
		}
