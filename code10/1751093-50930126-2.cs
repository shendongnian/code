    if (oWordDoc.Bookmarks.Exists("nameandage"))
    {
         Object name = "nameandage";
        Range range = oWordDoc.Bookmarks.get_Item(ref name).Range;
        range.Text = sb.ToString(); //Assign contents here
        object newRange = range;
        oWordDoc.Bookmarks.Add("name", ref newRange);
    }
