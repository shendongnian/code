    SqlQuery sq = new Select(TableOne.Columns.MemberId + " AS MemberId",
        TableTwo.Columns.Name + " AS MemberName",
        TableOne.Columns.ExpiryOn + " AS MembershipExpiresOn",
        TableFour.Columns.Name + " AS Country")
      .From(TableOne.Schema)
      .InnerJoin(TableTwo.Schema)
      .InnerJoin(TableThree.Schema)
      .InnerJoin(TableFour.Schema)
      .Where(TableTwo.Columns.Name).Like("A%");
