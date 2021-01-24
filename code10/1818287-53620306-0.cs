    Word.Document doc = Globals.ThisAddin.Application.ActiveDocument;
    Word.Style style = doc.Styles[Word.WdBuildinStyle.wdStyleNormal];
    float size = style.Size;
    string font = style.Font.Name;
    foreach (Word.Paragraph paragraph in doc)
    {
        if (paragraph.Range.get_Style() = Word.WdBuildinStyle.wdStyleHeading1)
        {
         paragraph.Range.Font.Size = size;
         paragraph.Range.Font.Name = font;
         }
    }
