    public static bool WriteMenu(List<Page> pages, int parentId, int indent)
    {
        string padding = new string(' ', indent * 8);
        bool writtenAny = false;
        foreach (var page in pages.Where(p => p.ParentPageId == parentId))
        {
            if (!writtenAny)
            {                
                Console.WriteLine();
                Console.WriteLine(padding + "<ul>");
                writtenAny = true;
            }
            Console.Write(padding + "    <li>{0}", page.PageId);
            if (WriteMenu(pages, page.PageId, indent + 1))
            {
                Console.WriteLine(padding + "    </li>");                
            }
            else
            {
                Console.WriteLine("</li>");
            }
        }        
        if (writtenAny)
        {
            Console.WriteLine(padding + "</ul>");
        }
        return writtenAny;
    }    
    ...
    WriteMenu(pages, 0, 0);
