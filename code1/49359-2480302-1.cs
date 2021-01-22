    bool isImageValid = true;
    try
    {
        using (FileStream fs = new FileStream("C:\\Images\\Test.jpg", FileMode.Open))
        {
            BitmapFrame bmpFrame = BitmapFrame.Create(fs);
        }
    }
    catch
    {
        isImageValid = false;
    }
    File.Move("C:\\Images\\Test.jpg", "C:\\Images\\Test0.jpg");
