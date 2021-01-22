    public ArrayList ConvertDT(ref DataTable dt)
    {
            ArrayList converted = new ArrayList(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                    converted.Add(row);
            }
            return converted;
    }
