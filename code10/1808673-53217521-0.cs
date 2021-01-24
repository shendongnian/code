    var stringBuiler = new StringBuilder("Select ID, email FROM DBTABLE WHERE email in (");
    // create "cmd" as a DB-provider-specific DbCommand instance, with "using"
    using (...your reader...)
    {
        int idx = 0;
        ...
        while ((line = stringReader.ReadLine()) != null)
        {
            // ...
            Guid val = Guid.Parse(line);
            // ...
            var p = cmd.CreateParameter();
            p.Name = "@p" + idx;
            p.Value = val;
            if (idx != 0) stringBuiler.Append(",");
            stringBuiler.Append(p.Name);
            cmd.Parameters.Add(cmd);
            idx++;
        }
    
    }
    cmd.CommandText = stringBuiler.Append(")").ToString();
