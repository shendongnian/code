    using (EntityConnection conn = new EntityConnection("name=MyConnection")) {
      conn.Open();
      var qry = "Select * From MyTable";
      using (EntityCommand cmd = new EntityCommand(query, conn) {
        var queryExpression = query.Expression;
      }
    }
