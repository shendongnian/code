        DataTable GetConflictTable()
        {
            Type type = _conflictEnumerator.Current[0].GetType();
            List<string> headers = null;
            foreach (var mi in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
            {
                if (mi.Name == "GetHeaders")
                {
                    headers = mi.Invoke(null, null) as List<string>;
                    break;
                }
            }
            var table = new DataTable();
            if (headers != null)
            {
                foreach (var h in headers)
                {
                    table.Columns.Add(h);
                }
                foreach (var c in _conflictEnumerator.Current)
                {
                    table.Rows.Add(c.GetFieldsForDisplay());
                }
            }
            return table;
        }
