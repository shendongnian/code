    var deposits = (from x in db.Deposits select new { x.DepositDate, x.Amount })
        .ToArray()
        .GroupBy(x => x.DepositDate.Year)
        .Select(g => new { Year = g.Key, Amount = g.Sum(y => y.Amount) })
        .ToArray();
    var Depseries = chart1.Series.Add("Deposit");
    Depseries.XValueMember = "Year";
    Depseries.YValueMembers = "DepositAmount";
    Depseries.Name = "Deposit";
    chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
    chart1.Series["Deposit"].IsValueShownAsLabel = true;
    Depseries.CustomProperties = "LabelStyle=Left";
    chart1.Series["Deposit"].Points.DataBind(deposits, "Year", "Amount", null);
    var debits = (from x in db.Debits select new { x.DebitDate, x.Amount })
        .ToArray()
        .GroupBy(x => x.DebitDate.Year)
        .Select(g => new { Year = g.Key, Amount = g.Sum(y => y.Amount) })
        .ToArray();
    var Debseries = chart1.Series.Add("Debit");
    Debseries.XValueMember = "Year";
    Debseries.YValueMembers = "DebitAmount";
    Debseries.Name = "Debit";
    chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
    chart1.Series["Debit"].IsValueShownAsLabel = true;
    Debseries.CustomProperties = "LabelStyle=Left";
    chart1.Series["Debit"].Points.DataBind(debits, "Year", "Amount", null);
    ...
