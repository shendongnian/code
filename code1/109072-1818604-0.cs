    DataTable HouseInformation = new DataTable("HouseInformation");
    DataColumn colName = HouseInformation.Columns.Add("NameOfHouse");
    DataColumn colPrice = HouseInformation.Columns.Add("Price");
    // Add Data
    DataRow newRow = HouseInformation.NewRow();
    newRow[colName] = "Name of House 1";
    newRow[colPrice] = 400000;
    HouseInformation.Rows.Add(newRow);
