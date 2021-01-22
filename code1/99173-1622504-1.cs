        var parent = bookmark.Parent;   // bookmark's parent element
        // loop till we get the containing element in case bookmark is inside a table etc.
        // keep checking the element's parent and update it till we reach the Body
        var tempParent = bookmark.Parent;
        bool isInTable = false;
        while (tempParent.Parent != mainPart.Document.Body)
        {
            tempParent = tempParent.Parent;
            if (tempParent is Table && !isInTable)
                isInTable = true;
        }
        
        // ... 
        newParagraph.InsertAfterSelf(table);  // from above sample
        // if bookmark is in a table, add a paragraph after table
        if (isInTable)
            table.InsertAfterSelf(new Paragraph());
