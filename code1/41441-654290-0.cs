    public static class Extensions
    {
    
        public static string JoinStrings(this DataReader reader, int position, string delimiter)
        {
            string delim = "";
            StringBuilder sb = new StringBuidler();
            while (reader.Read())
            {
               sb.Append(reader[position]).Append(delim);
               delim = delimiter;
            }
            return sb.ToString();
        }
    }
