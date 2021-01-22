    try
    {
        Image image = Image.FromFile(imageFile);
    
        PictureBox eachPictureBox = new PictureBox();
    
        eachPictureBox.Size = new Size(100,100);
    
        eachPictureBox.Location = new Point(iCtr * 100 + 1, 1);
        eachPictureBox.Image = Image.FromFile(imageFile);
        iCtr++;
    
        panel1.Controls.Add(eachPictureBox);
    }
    catch(OutOfMemoryException) { } // skip the file
