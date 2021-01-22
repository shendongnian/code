    private void RotateAndSaveImage(String input, String output)
    {
        //create an object that we can use to examine an image file
        using (Image img = Image.FromFile(input))
        {
            //rotate the picture by 90 degrees and re-save the picture as a Jpeg
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            img.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
