    string year = DateTime.Now.Year.ToString();
    sb.Append(DateTime.Now.AddMonths(1));
    sb.Append(DateTime.Now.Day);
    sb.Append(year.Substring(2));
    sb.Append(DateTime.Now.Hour);
    sb.Append(DateTime.Now.Minute);
