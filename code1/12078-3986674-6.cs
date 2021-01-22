    private IEnumerable<KeyValuePair<object,object>> GetDisplayTable(DataTable dataTable,  DataColumn ValueMember, string sep,params DataColumn[] DisplayMembers)
    {
        yield return new KeyValuePair<object,object>("<ALL>",null);
        if (DisplayMembers.Length < 1)
            throw new ArgumentException("At least 1 DisplayMember column is required");
        foreach (DataRow r in dataTable.Rows)
        {
            StringBuilder sbDisplayMember = new StringBuilder();
            foreach(DataColumn col in DisplayMembers)
            {
                if (sbDisplayMember.Length > 0) sbDisplayMember.Append(sep);
                sbDisplayMember.Append(r[col]);
            }
            yield return new KeyValuePair<object, object>(sbDisplayMember.ToString(), r[ValueMember]);
        }
    }
