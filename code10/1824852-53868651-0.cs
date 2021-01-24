     foreach (Control ctrl in this.Controls)
     {
         if (ctrl is PictureBox)  //determine if the control is a picture box
         {
             var pic = (PictureBox)ctrl; //cast to picture box
             pic.Image = Image.FromFile("../Pics/Salmon.jpg");
         }
     }
