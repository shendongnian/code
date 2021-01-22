        Public static void ReplaceBookmarkParagraphs(WordprocessingDocument doc, string bookmark, string text)
        {
            //Find all Paragraph with 'BookmarkStart' 
            var t = (from el in doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>()
                     where (el.Name == bookmark) &&
                     (el.NextSibling<Run>() != null)
                     select el).First();
            //Take ID value
            var val = t.Id.Value;
            //Find the next sibling 'text'
            OpenXmlElement next = t.NextSibling<Run>();
            //Set text value
            next.GetFirstChild<Text>().Text = text;
            
            //Delete all bookmarkEnd node, until the same ID
            deleteElement(next.GetFirstChild<Text>().Parent, next.GetFirstChild<Text>().NextSibling(), val, true);
        }
