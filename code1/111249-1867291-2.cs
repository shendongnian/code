    Image myImage = Image.FromFile(//path);
    picobx.Image = myImage;
    //click button
    picobx.Image = null;
    myImage.Dispose();
    File.Delete(//path);
