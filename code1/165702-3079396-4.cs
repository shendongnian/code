    System.Data.DataTable DT1 = new System.Data.DataTable("Houses");
    System.Data.DataTable DT2 = new System.Data.DataTable("Streets");
    DT1.Columns.Add("Name", typeof(string));
    DT1.Columns.Add("Number", typeof(int));
    DT2.Columns.Add("Street", typeof(string));
    DT2.Columns.Add("FirstHouseNumber", typeof(int));
    DT2.Columns.Add("LastHouseNumber", typeof(int));
    DT1.Rows.Add("Chris", 123);
    DT1.Rows.Add("Ben", 456);
    DT1.Rows.Add("Joe", 789);
    DT2.Rows.Add("Broadway", 100, 500);
    DT2.Rows.Add("Main", 501, 1000);
    var funcquery = from System.Data.DataRow name in DT1.Rows
                    from System.Data.DataRow street in DT2.Rows
                    where (int)name["Number"] >= (int)street["FirstHouseNumber"]
                    && (int)name["Number"] <= (int)street["LastHouseNumber"]
                    select new { Name = name["Name"], Number = name["Number"], Street = street["Street"] };
    var results = funcquery.ToArray();
    for (int i = 0; i < results.Length; i++)
    {
       Console.WriteLine("{0} {1} {2}", results[i].Name, results[i].Number, results[i].Street);
    }
