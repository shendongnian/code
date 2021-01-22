    public static string Debugify(this DbParameterCollection parameters) {
        List<string> ParameterValuesList = new List<string>();
    
        foreach (DbParameter Parameter in parameters) {
            string ParameterName, ParameterValue;
            ParameterName = Parameter.ParameterName;
    
            if (Parameter.Direction == ParameterDirection.ReturnValue)
                continue;
    
            if (Parameter.Value == null || Parameter.Value.Equals(DBNull.Value))
                ParameterValue = "NULL";
            else
            {
                switch (Parameter.DbType)
                {
                    case DbType.String:
                    case DbType.Date:
                    case DbType.DateTime:
                    case DbType.Guid:
                    case DbType.Xml:
                        ParameterValue
                            = "'" + Parameter
                                    .Value
                                    .ToString()
                                    .Replace(Environment.NewLine, "")
                                    .Left(80, "...") + "'"; // Left... is another nice one
                        break;
    
                    default:
                        ParameterValue = Parameter.Value.ToString();
                        break;
                }
    
                if (Parameter.Direction != ParameterDirection.Input)
                    ParameterValue += " " + Parameter.Direction.ToString();
            }
    
            ParameterValuesList.Add(string.Format("{0}={1}", ParameterName, ParameterValue));
        }
    
        return string.Join(", ", ParameterValuesList.ToArray());
    }
