        using (DirectoryEntry dirEntry = new DirectoryEntry(strchild))
        {
            foreach (string strPropertyName in dirEntry.Properties.PropertyNames)
            {
                Console.WriteLine(strPropertyName + " " + dirEntry.Properties[strPropertyName].Value.ToString());
            }
        }
