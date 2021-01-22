            Console.WriteLine("<ul>");
            foreach (var page in pages)
            {
                if (page.parentPageId == 0)
                {
                    WriteMenu(pages, page);
                }
            }
            Console.WriteLine("</ul>");
        private static void WriteMenu(List<Page> pages, Page page)
        {
            Console.WriteLine("<li>" + page.pageId);
            var subpages = pages.Where(p => p.parentPageId == page.pageId);
            if (subpages.Count() > 0)
            {
                Console.WriteLine("<ul>");
                foreach (Page p in subpages)
                {
                    if (pages.Count(x => x.parentPageId == p.pageId) > 0)
                        WriteMenu(pages, p);
                    else
                        Console.WriteLine(string.Format("<li>{0}</li>", p.pageId));
                }
                Console.WriteLine("</ul>");
            }
            Console.WriteLine("</li>");
        }
