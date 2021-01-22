    Pages pages = new Pages();
    for(int i=1; i<=4;i++)
    {
        Page p = new Page();
        p.name = "Page Name " + i;
        p.url = "/page-" + i + "/";
        pages.Pages.Add(p);
    }
    Console.Write(pages.ToXml());
