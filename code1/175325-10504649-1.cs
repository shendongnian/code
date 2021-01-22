        private static void ReplaceBookmarkParagraphs(MainDocumentPart doc, string bookmark, IEnumerable<OpenXmlElement> paras) {
            var start = doc.Document.Descendants<BookmarkStart>().Where(x => x.Name == bookmark).First();
            var end = doc.Document.Descendants<BookmarkEnd>().Where(x => x.Id.Value == start.Id.Value).First();
            OpenXmlElement current = start;
            var done = false;
            while ( !done && current != null ) {
                OpenXmlElement next;
                next = current.NextSibling();
                if ( next == null ) {
                    var parentNext = current.Parent.NextSibling();
                    while ( !parentNext.HasChildren ) {
                        var toRemove = parentNext;
                        parentNext = parentNext.NextSibling();
                        toRemove.Remove();
                    }
                    next = current.Parent.NextSibling().FirstChild;
                    current.Parent.Remove();
                }
                if ( next is BookmarkEnd ) {
                    BookmarkEnd maybeEnd = (BookmarkEnd)next;
                    if ( maybeEnd.Id.Value == start.Id.Value ) {
                        done = true;
                    }
                }
                if ( current != start ) {
                    current.Remove();
                }
                current = next;
            }
            foreach ( var p in paras ) {
                end.Parent.InsertBeforeSelf(p);
            }
        }
