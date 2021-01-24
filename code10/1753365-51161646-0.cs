    using System.Collections.Specialized;
    ...
    ...
    
    DocX doc = DocX.Create("bullet-text.docx");
    
    List list;
    for (var i = 0; i < count; i++)
    {
        var currentItem = bulletList[i];
        var item = currentItem.Replace(@"\", "");
        int listLevel = currentItem.ToList().Where(x => x == '\\').Select(x => x).Count();
    
        if (i == 0)
            list = doc.AddList("item 1", listLevel, ListItemType.Numbered);
        else
            doc.AddListItem(list, "item 2", listLevel);
    
        doc.InsertList(list);
    }
    doc.Save();
    
    //Copy the Filename to Clipboard (setFile function uses StringCollection)
    StringCollection collection = new StringCollection();
    collection.Add(Environment.CurrentDirectory + "\\bullet-text.docx");
    Clipboard.SetFileDropList(collection);
    
    // Collapse the range to the end, as to not overwrite it. Unsure if you need this
    range.Collapse(wdCollapseEnd);
    
    //Paste into the selected Range.
    range.Paste();
