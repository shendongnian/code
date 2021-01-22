            string lastGroup = string.Empty;
            int i = 0;
            Dictionary<string, string> dictionary = new Dictionary<string, string>(); 
            foreach (string o in lbxMain.Items)
            {
                if (o.StartsWith("Group:"))
                    lastGroup = lbxMain.Items[i].ToString();
                if (o.StartsWith("Item:"))
                    dictionary.Add(o + " " + i, lastGroup);
                i++;
            }
