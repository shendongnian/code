    using (DirectorySearcher searcher = new DirectorySearcher("(cn=Test)"))
    {
        SearchResult result = searcher.FindOne();
        if (result != null)
        {
            DirectoryEntry entry = result.GetDirectoryEntry();
            string s = entry.InvokeGet("TerminalServicesHomeDrive") as string;
            MessageBox.Show(s ?? "null");
        }
    }
