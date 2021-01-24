    var drawing = new List<IDrawable>
    {
        new AquaCircle(),
        new RedCircle(),
    };
    var imageFile = new Bitmap(200, 200);
    using (var g = Graphics.FromImage(imageFile))
    {
        for (var i = 0; i < drawing.Count; i++)
        {
            drawing[i].Draw(g);
        }
    }
    imageFile.Save("test.jpg");
