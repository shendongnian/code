        string LogCommand(SqlCommand cmd)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(cmd.CommandText);
            foreach (SqlParameter param in cmd.Parameters)
            {
                sb.Append(param.ToString());
                sb.Append(" = \"");
                sb.Append(param.Value.ToString());
                sb.AppendLine("\"");
            }
            return sb.ToString();
        }
