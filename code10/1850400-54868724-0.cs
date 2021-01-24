               DataTable parentTable = new DataTable();
               parentTable.Columns.Add("ParentId", typeof(string));
               parentTable.Columns.Add("Name", typeof(string));
               DataTable childTable = new DataTable();
               childTable.Columns.Add("ParentId", typeof(string));
               childTable.Columns.Add("ChildNameName", typeof(string));
               DataTable relationshipTable = new DataTable();
               relationshipTable.Columns.Add("RelationshipId", typeof(string));
               relationshipTable.Columns.Add("PrimaryId", typeof(string));
               relationshipTable.Columns.Add("SecondaryId", typeof(string));
               var results = (from r in relationshipTable.AsEnumerable()
                              join p in parentTable.AsEnumerable() on r.Field<string>("PrimaryId") equals p.Field<string>("ParentId")
                              join c in childTable.AsEnumerable() on r.Field<string>("SecondaryId") equals c.Field<string>("ChildID")
                              select new { r = r, p = p, c = c })
                             .ToList();
