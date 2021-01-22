    public IEnumerable<Rec_A> getModifiedItems()
    {
      foreach (Rec_A rec in this.Values)
      {
         if (rec.modified)
            yield return rec;
      }
    }
