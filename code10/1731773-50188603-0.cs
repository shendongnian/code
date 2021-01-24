    using (DocX document = DocX.Create(ListSample.ListSampleOutputDirectory + @"AddList.docx"))
    {
        // Add a title
        document.InsertParagraph("Adding lists into a document").FontSize(15d).SpacingAfter(50d).Alignment = Alignment.center;
    
        // Add a numbered list where the first ListItem is starting with number 1.
        var numberedList = document.AddList("Berries", 0, ListItemType.Numbered, 1);
    
        // Add Sub-items(level 1) to the preceding ListItem.
        document.AddListItem(numberedList, "Strawberries", 1);
        document.AddListItem(numberedList, "Blueberries", 1);
        document.AddListItem(numberedList, "Raspberries", 1);
        // Add an item (level 0)
        document.AddListItem(numberedList, "Banana");
        // Add an item (level 0)
        document.AddListItem(numberedList, "Apple");
        // Add Sub-items(level 1) to the preceding ListItem.
        document.AddListItem(numberedList, "Red", 1);
        document.AddListItem(numberedList, "Green", 1);
        document.AddListItem(numberedList, "Yellow", 1);
    
        // Insert the lists into the document.
        document.InsertParagraph("This is a Numbered List:\n");
        document.InsertList(numberedList, new Xceed.Words.NET.Font("Cooper Black"), 15);
    
        document.Save();
        document.Dispose();
    }
