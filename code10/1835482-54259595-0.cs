    using HooverUnlimited.DotNetRtfWriter;
    ...
    public void SaveMyFile(string datastring)
    {
        RtfDocument doc = new RtfDocument(
            HooverUnlimited.DotNetRtfWriter.PaperSize.Letter,
            PaperOrientation.Portrait,
            Lcid.English);
        doc.Margins[Direction.Top] = 1 * 72;
        doc.Margins[Direction.Left] = 1.25f * 72;
        doc.Margins[Direction.Bottom] = 1 * 72;
        doc.Margins[Direction.Right] = 1.25f * 72;
        doc.SetDefaultFont("LinoScript");
        RtfParagraph para = doc.AddParagraph();
        RtfCharFormat format = para.AddCharFormat();
        format.FontSize = 24;
        para.SetText(datastring);
        doc.Save(@textBox1.Text.Trim() + numericUpDown1.Value.ToString() + "image.rtf");
    }
