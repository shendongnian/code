    foreach (Control p in panel.Controls)
    {
      if (p is PictureBox) // Use the keyword is to see if P is type of Picturebox
      {
         p.Location.X = 50;
      }
    }
