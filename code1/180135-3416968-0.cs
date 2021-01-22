    public static void WriteMenu(List<Page> pages, int parentId)
    {
        bool first = true;
        foreach (var page in pages.Where(p => p.ParentPageId == parentId))
        {
            if (first)
            {
                Console.WriteLine("<ul>");
                first = false;
            }
            Console.WriteLine("<li>{0}", page.pageId);
            WriteMenu(pages, page.pageId);
        }        
        if (!first)
        {
            Console.WriteLine("</ul>");
        }
    }
    ...
    WriteMenu(pages, 0);
