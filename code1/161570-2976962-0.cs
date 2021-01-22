    private void AddAlphaButtons()
    {
        char alphaStart = Char.Parse("A");
        char alphaEnd = Char.Parse("Z");   
    
        int x = 0;  // used for location info
        int y = 0;  // used for location info
    
        for (char i = alphaStart; i <= alphaEnd; i++)
        {
            string anchorLetter = i.ToString();
            Button Buttonx = new Button();
            Buttonx.Name = "button " + anchorLetter;
            Buttonx.Text = anchorLetter;
            Buttonx.BackColor = Color.DarkSlateBlue;
            Buttonx.ForeColor = Color.GreenYellow;
            Buttonx.Width = 30;
            Buttonx.Height = 30;
    
            // set button location
            Buttonx.Location = new Point(x, y);
    
            x+=30;
            if(x > panel1.Width - 30)
            { 
                x = 30;
                y+=30;
            }
    
            this.panelButtons.Controls.Add(Buttonx);
    
            //Buttonx.Click += new System.EventHandler(this.MyButton_Click);
         }
    }
