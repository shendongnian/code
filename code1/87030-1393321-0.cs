    dt = new DataTable();
    dt.Columns.Add("SrNo", typeof(int));
    dt.Columns[0].AutoIncrement = true;
    dt.Columns[0].AutoIncrementSeed = 1;
    dt.Columns[0].AutoIncrementStep = 1;
    
    adp.Fill(dt);
