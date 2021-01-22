    // Psudo code - can't check the C# spec atm.
    foreach(Pixel p in image)
    {
        // get average of colour components.
        double greyScale = (p.Red + p.Green + p.Blue) / 3;
        totalIntensity += greyScale;
    }
    double averageImageIntensity = totalIntensity / image.NumPixels;
    if(totalIntensity > 128) // image could be considered to be "white"
    else // image could be considered "black".
