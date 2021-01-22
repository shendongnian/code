    public static class Extensions
    {
    
        public static string JoinStrings(this DataReader reader, int ColumnIndex, string delimiter)
        {
            var delim = String.Empty;
            var sb = new StringBuidler();
            while (reader.Read())
            {
               sb.Append(reader[ColumnIndex].ToString()).Append(delim);
               delim = delimiter;
            }
            return sb.ToString();
        }
    }
