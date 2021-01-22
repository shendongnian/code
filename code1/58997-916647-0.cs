    UserCollection ActiveUsersNotExempt = DB.Select().From<User>()
      .Where(User.Columns.Active).IsEqualTo(true)
      .AndExpression(User.Columns.Exempt).IsNotEqualTo(true)
      .Or(User.Columns.Exempt).IsNull()
      .ExecuteAsCollection<UserCollection>();`
