    string[] criteriaFields = ConfigurationManager.AppSettings["strFilter"].Split(',').Select(x => x.Trim()).ToArray();
    List<string> excelAddresses = new List<string>();
    for (int i = 0; i < dtExcel.Rows.Count; i++)
    {
        StringBuilder compareAdressExcel = new StringBuilder();
        foreach (String cFieldTrimmed in criteriaFields)
        {
            if (cFieldTrimmed == "Strasse")
            {
                var normalizedValue = dtExcel.Rows[i][cFieldTrimmed].ToString()
                    .ToLower()
                    .Replace(" ", "")
                    .Replace("str", "strasse")
                    .Replace("straße", "strasse")
                    .Replace("str.", "strasse");
                compareAdressExcel.Append(normalizedValue);
            }
            else
            {
                compareAdressExcel.Append(dtExcel.Rows[i][cFieldTrimmed].ToString().Replace(" ", "").ToLower());
            }
        }
        excelAddresses.Add(compareAdressExcel.ToString());
    }
