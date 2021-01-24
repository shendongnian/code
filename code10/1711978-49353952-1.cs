    DoStuffWithDataTable(
        "Select...",
        table => 
        { // of course, that doesn't have to be a lambda expression here...
            foreach (DataRow row in table.Rows) // search whole table
            {
                if ((int)row["Id"] == 4)
                {
                    row["Value2"] = 12345;
                }
                else if ((int)row["Id"] == 5)
                {
                    row.Delete();
                }
            }
        },
        new SqlParameter[]
        {
            new SqlParameter("@FirstValue", 2),
            new SqlParameter("@SecondValue", 3)
        }
        );
