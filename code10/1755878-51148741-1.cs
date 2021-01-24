    Point? point = browser.VerifyImageExists(imageToFind);
    if (point.HasValue) {
        Console.WriteLine("Image found at {0}", point.Value);
    }
    else {
        Console.WriteLine("Image not found");
    }
