    DateTime dtTemp = DateTime.MinValue;
    StringBuilder sb = new StringBuilder();
    foreach(DateTime dt in MyDateList)
    {
        if (dt == dtTemp) sb.AppendLine(dt.ToString("HH:mm:ss"));
        else
        {
            dtTemp = dt;
            sb.AppendLine();
            sb.AppendLine(dt.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }
    Console.WriteLine(sb.ToString().Trim());
