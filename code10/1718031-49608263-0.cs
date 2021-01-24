    var queryResult = db.Users.SqlQuery(@"EXECUTE uspAddUser @1, @2, @3, @4, @5, @6",
                                            new SqlParameter("1", user.userFirstName),
                                            new SqlParameter("2", user.userLastName),
                                            new SqlParameter("3", user.userName),
                                            new SqlParameter("4", user.userEmail),
                                            new SqlParameter("5", user.userPassword),
                                            new SqlParameter("6", user.userDateOfBirth)).Single();
