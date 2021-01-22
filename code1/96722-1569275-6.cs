    StringBuilder sb = new StringBuilder();
    string year = DateTime.Now.Year.ToString();
    sb.Append(String.Format("Next Month is: {0} \n ",DateTime.Now.AddMonths(1)));
    sb.Append(String.Format("Day is {0}\n ", DateTime.Now.Day));
    sb.Append(String.Format("Year is {0}\n ", year.Substring(2)));
    sb.Append(String.Format("The Hour is {0}\n ", DateTime.Now.Hour)); //getting late
    sb.Append(String.Format("The Minute is {0}\n ", DateTime.Now.Minute));
