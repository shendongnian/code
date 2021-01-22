    public static void InsertIntoBookmark(BookmarkStart bookmarkStart, string text)
    {
        OpenXmlElement elem = bookmarkStart.NextSibling();
        while (elem != null && !(elem is BookmarkEnd))
        {
            OpenXmlElement nextElem = elem.NextSibling();
            elem.Remove();
            elem = nextElem;
        }
        bookmarkStart.Parent.InsertAfter<Run>(new Run(new Text(text)), bookmarkStart);
    }
