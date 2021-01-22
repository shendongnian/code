    public void DeleteFirstLink()
    {
      using (ProjectEntities db = new ProjectEntities())
      {
        db.AttachTo("[your site EntitySet name - SiteSet?]", this);
        var link = LinkSet.First();
        db.DeleteObject(link);
        LinkSet.Remove(link);
        db.SaveChanges();
      }
    }
