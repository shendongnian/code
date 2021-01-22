        private static void CommandAsSql_Text(this SqlCommand command, System.Text.StringBuilder sql)
        {
            string query = command.CommandText;
            foreach (SqlParameter p in command.Parameters)
                query = Regex.Replace(query, "\\B" + p.ParameterName + "\\b", p.ParameterValueForSQL()); //the first one is \B, the 2nd one is \b, since ParameterName starts with @ which is a non-word character in RegEx (see https://stackoverflow.com/a/2544661)
            sql.AppendLine(query);
        }
