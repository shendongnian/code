    public IEnumerable<Products> GetQuery() {
      var query = db.GetTable<Products>();
      if ( automotiveBox.Checked ) {
        query = query.Where(x => x.Automotive == 1);
      }
      if ( aviation.Checked ) {
        query = query.Where(x => x.Aviation == 1);
      }
      return query
    }
