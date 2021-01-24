     protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            WebPartManager wpm = (WebPartManager)WebPartManager.GetCurrentWebPartManager(this.Page);
            TextBox testBox = new TextBox
            {
                ForeColor = System.Drawing.Color.Blue,
                ID = "testID",
                Width = 500,
                Height = 200
            };          
            
            GenericWebPart testGWP = wpm.CreateWebPart(testBox);
           
            wpm.AddWebPart(testGWP, wpm.Zones["WebPartZone4"], 1);
        }
