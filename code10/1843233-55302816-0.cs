    if (bookMarkEnd.Key == "F_4000" || bookMarkEnd.Key == "F_4002")
    {
         OpenXmlElement previousSibling = bookMarkEnd.Value.Parent.PreviousSibling();
         while (previousSibling is BookmarkStart || previousSibling is BookmarkEnd)
         {
             previousSibling = previousSibling.PreviousSibling();
         }
         OpenXmlElement next = bookMarkEnd.Value.NextSibling<Run>();
         if (next != null)
         {
             next.GetFirstChild<Text>().Text = bookMarkEnd.Key + " " + "F_4002";
         }
    }
