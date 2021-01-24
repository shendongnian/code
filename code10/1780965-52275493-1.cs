     foreach (ForeignKeyCollection fkcol in fkcolList) // Generate Relations
            {
                foreach (ForeignKey fk in fkcol)
                {
                    StringCollection sc = fk.Script();
                    foreach (string s in sc)
                    {
                        sb.AppendLine(s);
                    }
                }
            }
            fkcolList.Clear();
