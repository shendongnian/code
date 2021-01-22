    var pics = new PictureBox[] {pictureBox7, 
                                 pictureBox8, 
                                 pictureBox9, 
                                 pictureBox10, etc... };, 
    pics.ToList().ForEach(p => p.BackColor = Color.FromArgb(187, 187, 187));
