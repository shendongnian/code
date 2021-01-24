    switch (reader.Name)
    {
        // found a node with name = "EntryNumber" (type = Element)
        case "EntryNumber":
            // read the text inside the element, which is a seperate node (type = Text)
            reader.Read();
            // get the value of the text node
            propEntryNo = reader.Value;
            break;
        // ...
    }
