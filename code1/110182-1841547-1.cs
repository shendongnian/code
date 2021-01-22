using(SPSite site = new SPSite("http://portal"))
{
    using (SPWeb web = site.RootWeb)
    {
        foreach (SPField field in web.Fields)
        {
            Console.WriteLine(field.Title);
        }
    }
}
