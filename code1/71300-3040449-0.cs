    public static IEnumerable<Announcementboard> GetSiteContent(string pageName, DateTime date)
    {
        IEnumerable<Announcementboard> content = null;
        IEnumerable<Announcementboard> addMoreContent = null;
            try
            {
                content = from c in DB.Announcementboards
                  //Can be displayed beginning on this date
                  where c.Displayondate > date.AddDays(-1)
                  //Doesn't Expire or Expires at future date
                  && (c.Displaythrudate == null || c.Displaythrudate > date)
                  //Content is NOT draft, and IS published
                  && c.Isdraft == "N" && c.Publishedon != null
                  orderby c.Sortorder ascending, c.Heading ascending
                  select c;
    
                //Get the content specific to page names
                if (!string.IsNullOrEmpty(pageName))
                {
                  addMoreContent = from c in content
                      join p in DB.Announceonpages on c.Announcementid equals p.Announcementid
                      join s in DB.Apppagenames on p.Apppagenameid equals s.Apppagenameid
                      where s.Apppageref.ToLower() == pageName.ToLower()
                      select c;
                }
    
                //CROSS-JOIN this content
                content = content.Union(addMoreContent);
    
                //Exclude dupes - effectively OUTER JOIN
                content = content.Distinct();
    
                return content;
            }
        catch (MyLovelyException ex)
        {
            throw ex;
        }
    }
