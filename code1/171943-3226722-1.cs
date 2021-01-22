        void InsertScripts(Database db)
        {
            var tables = db.Tables.ToIEnumerable(); //this is an extension method to convert Database.Tables into an IEnumerable<Table>             
            {
                foreach (var t in tables)
                {
                    var sb = new StringBuilder();
                    var sp = new StoredProcedure(db, "gen_insert_" + t.Name);
                    sp.AnsiNullsStatus = false;
                    sp.QuotedIdentifierStatus = false;
                    sp.TextMode = false;                    
                    var columns = t.Columns.ToIEnumerable().Where(c => !c.Identity && !c.IsReadOnly()).ToList();
                    foreach (var c in columns)
                    {
                        var p = new StoredProcedureParameter(sp, "@" + t.Name + "_" + c.Name, c.DataType);                        
                        p.IsCursorParameter = false;
                        
                        if(c.Default != null && c.Default.Length > 0)
                            p.DefaultValue = c.Default;
                        if (c.Nullable)
                            p.DefaultValue = "NULL";
                        sp.Parameters.Add(p);                        
                        
                    }
                    var cols = string.Join(",", columns.Select(c => c.Name).ToArray());
                    var vals = string.Join(",", columns.Select(c => "@" + t.Name + "_" + c.Name).ToArray());
                    
                    
                    var sql = string.Format("insert into {0} ({1}) values ({2});", t.Name, cols, vals);
                    sb.AppendLine(sql);
                    if (t.Columns.ToIEnumerable().Any(c => c.Identity))
                    {
                        var declaration = "declare @newid int;\r\n";
                        var ret = "select @newid = scope_identity();\r\nselect @newid;\r\nreturn @newid";
                        sb.Insert(0, declaration);
                        sb.AppendLine(ret);
                    }
                    sp.TextBody = sb.ToString();
                    if(cols.Length > 0 && sp.Parent.StoredProcedures[sp.Name] == null)
                        sp.Create();
                }
            }
        }
    public static class Utils //Extension methods...
    {
        public static IEnumerable<Table> ToIEnumerable(this TableCollection tables)
        {
            var list = new List<Table>();
            foreach (Table t in tables)
                list.Add(t);
            return list;
        }
        public static IEnumerable<View> ToIEnumerable(this ViewCollection views)
        {
            var list = new List<View>();
            foreach (View v in views)
                list.Add(v);
            return list;
        }
        public static IEnumerable<Column> ToIEnumerable(this ColumnCollection columns)
        {
            var list = new List<Column>();
            foreach (Column c in columns)
                list.Add(c);
            return list;
        }
        public static IEnumerable<ForeignKey> ToIEnumerable(this ForeignKeyCollection columns)
        {
            var list = new List<ForeignKey>();
            foreach (ForeignKey c in columns)
                list.Add(c);
            return list;
        }
        public static IEnumerable<string> ToIEnumerable(this ForeignKeyColumnCollection columns)
        {
            var list = new List<string>();
            foreach (ForeignKeyColumn c in columns)
                list.Add(c.Name);
            return list;
        }
    }
