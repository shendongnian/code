    Image DummyImage;
    // Paint
    lock (DummyImage)
        e.Graphics.DrawImage(DummyImage, 10, 10);
    // Access Image properties
    Size ImageSize;
    lock (DummyImage)
        ImageSize = DummyImage.Size;
