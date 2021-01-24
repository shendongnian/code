    Document document = new Document();
    document.LoadFromFile("2.docx");
    Section section = document.Sections[0];
    StringBuilder sb = new StringBuilder();
    foreach (Paragraph paragraph in section.Paragraphs)
    {
    foreach (DocumentObject obj in paragraph.ChildObjects)
    {
        if (obj is TextRange)
        {
            TextRange tr = obj as TextRange;
            if (tr.CharacterFormat.TextColor.ToArgb() == Color.Red.ToArgb())
            {
                sb.AppendLine(tr.Text);
            }
        }
    }
    File.WriteAllText("RedText.txt", sb.ToString());
    
