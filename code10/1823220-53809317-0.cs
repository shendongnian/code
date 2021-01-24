    public static void ExtractHeadingContent()
    {
        Document doc = new Document(MyDir + "input.docx");
        int i = 1;
        DocumentBuilder builder = new DocumentBuilder(doc);
        NodeCollection nodes = doc.GetChildNodes(NodeType.Paragraph, true);
        foreach (Paragraph paragraph in doc.GetChildNodes(NodeType.Paragraph, true))
        {
            if (paragraph.ParagraphFormat.IsHeading == true && paragraph.ParagraphFormat.StyleName.Equals("Heading 1"))
            {
                Paragraph newPar = new Paragraph(doc);
    
                paragraph.ParentNode.InsertBefore(newPar, paragraph);
                builder.MoveTo(newPar);
                builder.StartBookmark("bm_extractcontents" + i);
                builder.EndBookmark("bm_extractcontents" + i);
                i++;
            }
        }
    
        builder.MoveToDocumentEnd();
        builder.StartBookmark("bm_extractcontents" + i);
        builder.EndBookmark("bm_extractcontents" + i);
    
        for (int bm = 1; bm < i; bm++)
        {
            BookmarkStart bookmarkStart = doc.Range.Bookmarks["bm_extractcontents" + bm].BookmarkStart;
            BookmarkStart bookmarkEnd = doc.Range.Bookmarks["bm_extractcontents" + (bm + 1)].BookmarkStart;
            ArrayList extractedNodes = Common.ExtractContent(bookmarkStart, bookmarkEnd, false);
            Document dstDoc = Common.GenerateDocument(doc, extractedNodes);
            dstDoc.Save(MyDir + bm + "_out.docx");
        }
    }
