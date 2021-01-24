    var columns = 15;
    var rows = 10;
    var imageWidth = 32;
    var imageHeight = 32;
    var grid = new Grid();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            //Get the image in your project; I'm not sure how this is done in WinForms
            var b = new Bitmap(imageWidth, imageHeight);
            //Display it
            var pictureBox = new PictureBox();
            pictureBox.Image = b;
            //Set the position
            Grid.SetColumn(j, pictureBox);
            Grid.SetRow(i, pictureBox);
            //Insert into the "matrix"
            grid.Children.Add(pictureBox);
        }
    }
