    Tesseract.PageIteratorLevel myLevel = /*TODO*/;
    using (var page = Engine.Process(img))
    using (var iter = page.GetIterator())
    {
        iter.Begin();
        do
        {
            if (iter.TryGetBoundingBox(myLevel, out var rect))
            {
                var curText = iter.GetText(myLevel);
                // Your code here, 'rect' should containt the location of the text, 'curText' contains the actual text itself
            }
        } while (iter.Next(myLevel));
    }
