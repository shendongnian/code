    using(var con = new SqlConnection("..."))
    {
        con.Execute("UPDATE Usertable SET Name = @NewFN WHERE Name = @FN",
            new {
                  NewFN = getNewFirstName.Text,
                  FN = getFirstName.Text,
            });
    }
