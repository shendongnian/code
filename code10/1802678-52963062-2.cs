    for (int i = 0; i < WITestData.WIData.Length; i++)
    {
        string widthParameter = $"@width{counter}";
        string angleParameter = $"@angle{counter}";
        string commentParameter = $"@comment{counter}";
        parameterList.Add(widthParameter, OleDbType.Deciaml).Value = WITestData.WIData[i].Width;
        parameterList.Add(angleParameter, OleDbType.Decimal).Value = WITestData.WIData[i].Width;
        parameterList.Add(commentParameter, OleDbType.VarWChar).Value = WITestData.WIData[i].Comment;
        counter++;
    }
    parameterList.Add("@reportNumber", OleDbType.Integer).Value = WITestData.ReportNumber;
