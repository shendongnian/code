    using(SPSite site = new SPSite("http://yoursite"))
    using(SPWeb web = site.OpenWeb())
    {
        SPList list = web.Lists["your_doclib"];
        SPQuery query = new SPQuery()
        {
            Query = "",
            ViewAttributes = @"Scope=""RecursiveAll"""
        };
        SPListItemCollection itens = list.GetItems(query);
        foreach (SPListItem item in itens)
        {
            Console.ForegroundColor =
                item.FileSystemObjectType == SPFileSystemObjectType.Folder ?
                    ConsoleColor.White : ConsoleColor.Gray;
            Console.WriteLine("{0}", item.Name);
        }
    }
