    using (DirectoryEntry root = new DirectoryEntry(someDN))
    {
        DoSomething(root);
	}
    function DoSomething(DirectoryEntry de)
    {
        // Do some work here against the directory entry
        if (de.Children != null)
        {
            foreach (DirectoryEntry child in de.Children)
            {
                using (child)
				{
				    DoSomething(child);
				}
            }
        }
    }
