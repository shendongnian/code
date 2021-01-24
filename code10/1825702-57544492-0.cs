    private void TextToBitmap(string text)
    {
        try
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            using (var stream = new MemoryStream(bytes))
            {
                svgDoc = SvgDocument.Open<SvgDocument>(stream, null);
            }
            pictureBox1.Image = svgDoc.Draw();
        }
        catch { }
    }
