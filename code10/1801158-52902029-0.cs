        string storeProcContent = "select * from table1; select col1,col2,col5 from table2; select col8 from table3;";
        Regex rx = new Regex(@"select ([\w,\*]+?) from ([\w]+)", RegexOptions.IgnoreCase|RegexOptions.Compiled);
        MatchCollection matches = rx.Matches(storeProcContent);
        Console.WriteLine("{0} matches found in:\n   {1}",
                      matches.Count,
                      storeProcContent);
        foreach (Match match in matches)
        {
            GroupCollection groups = match.Groups;
            Console.WriteLine("Table name = {0}", groups[2].Value);
            Console.WriteLine("Column Used = {0}", groups[1].Value);
        }
