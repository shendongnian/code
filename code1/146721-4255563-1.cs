    switch (dt.Columns[col].DataType.FullName)
    {
        case "System.DateTime":
            formatedVal = ((DateTime)dataRow[col]).ToString("d");
            break;
        case "System.Date":
            formatedVal = ((DateTime)dataRow[col]).ToString();
            break;
        default:
            formatedVal = dataRow[col].ToString();
            break;
    }
