     foreach (Control ctrl in this.Controls)
     {
         if (ctrl is PictureBox picBox)  //determine if the control is a picture box
         {             
             picBox.Image = Image.FromFile("../Pics/Salmon.jpg");
         }
     }
