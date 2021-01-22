        private string GetActualQuery(SqlCommand sqlcmd)
        {
            string query = sqlcmd.CommandText;
            string parameters = "";
            string[] strArray = System.Text.RegularExpressions.Regex.Split(query, " VALUES ");
            //Reconstructs the second half of the SQL Command
            parameters = "(";
            int count = 0;
            foreach (SqlParameter p in sqlcmd.Parameters)
            {
                if (count == (sqlcmd.Parameters.Count - 1))
                {
                    parameters += p.Value.ToString();
                }
                else
                {
                    parameters += p.Value.ToString() + ", ";
                }
                count++;
            }
            parameters += ")";
            //Returns the string recombined.
            return strArray[0] + " VALUES " + parameters;
        }
