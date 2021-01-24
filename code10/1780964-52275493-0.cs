    List<ForeignKeyCollection> fkcolList = new List<ForeignKeyCollection>();
    foreach (Table t in db.Tables)
            {
                fkcolList.Add(t.ForeignKeys); // Extract the foreign keys
                if (!t.IsSystemObject)
                {
                    StringCollection sc = t.Script(scriptopt);
                    foreach (string s in sc)
                    {
                        sb.AppendLine(s);
                    }
                }
            }
