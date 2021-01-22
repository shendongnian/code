    string values = string.Empty;
                types.ForEach(s =>
                {
                   if (!string.IsNullOrEmpty(values))
                       values += ",";
                   values += string.Format("'{0}'", s);
                   
                });
