    bool isImageValid = true;
    try
    {
        BitmapFrame bmpFrame = BitmapFrame.Create(new Uri("C:\\Images\\Test.jpg"));
    }
    catch
    {
        isImageValid = false;
    }
    File.Move("C:\\Images\\Test.jpg", "C:\\Images\\Test0.jpg");
