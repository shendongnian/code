            // Create string to save last 'used' group in.
            string lastGroup = string.Empty;
            // Create counter to check what index we are at in the ListBox.
            int i = 0;
            // Create a dictionary to store <string Item, string Group>.
            Dictionary<string, string> dictionary = new Dictionary<string, string>(); 
            // Loop every item (as string) in the ListBox.
            foreach (string o in lbxMain.Items)
            {
                // If the item is a group:
                if (o.StartsWith("Group:"))
                    // Put the name of the item into the lastGroup variable so we know where to put the items in.
                    lastGroup = lbxMain.Items[i].ToString();
                // If the item is an item:
                if (o.StartsWith("Item:"))
                    // Put the item into a dictionary with the lastGroup variable saying what group it's part of.
                    dictionary .Add(o + " " + i, lastGroup);
                // Increase i so we keep an eye on the indices.
                i++;
            }
