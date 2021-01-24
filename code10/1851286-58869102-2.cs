         private void CreateControlsPlayer(String pictureName, int rankValueCard, Panel panel)
        {
            string folder = "Cards/";
            string fileExtension = ".png";
            //creates dynamically picturebox
            var newpictureBox = new PictureBox();
            newpictureBox.Width = 70;
            newpictureBox.Height = 130;
            newpictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newpictureBox.Image = Image.FromFile(folder + pictureName + fileExtension);
            newpictureBox.Location = new Point(xPlayer, 60);
            newpictureBox.Visible = true;
            newpictureBox.Name = "picBox" + "_" + xPlayer;
            xPlayer = xPlayer + 30;
            
            panel.Controls.Add(newpictureBox);
        }
