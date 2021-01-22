    public static Tag CreateTag(string name)
    {
      try
      {
        using (ISession session = factors.CreateSession())
        {
          session.BeginTransaction();
          Tag existingTag = session.CreateCriteria(typeof(Tag)) /* .... */
          if (existingtag != null) return existingTag;
          {
            session.Save(new Tag(name));
          }
          session.Transaction.Commit();
        }
      }
      // catch the unique constraint exception you get
      catch (WhatEverException ex)
      {
        // try again
        return CreateTag(name);
      }
    }
