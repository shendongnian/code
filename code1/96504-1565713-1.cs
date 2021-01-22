        protected virtual void ExecuteScript(SqlConnection connection, string script)
        {
            string[] commandTextArray = System.Text.RegularExpressions.Regex.Split(script, "\r\n[\t ]*GO");
            SqlCommand _cmd = new SqlCommand(String.Empty, connection);
            foreach (string commandText in commandTextArray)
            {
                if (commandText.Trim() == string.Empty) continue;
                if ((commandText.Length >= 3) && (commandText.Substring(0, 3).ToUpper() == "USE"))
                {
                    throw new Exception("Create-script contains USE-statement. Please provide non-database specific create-scripts!");
                }
                _cmd.CommandText = commandText;
                _cmd.ExecuteNonQuery();
            }
            
        }
