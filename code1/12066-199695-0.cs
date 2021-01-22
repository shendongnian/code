    DataTable hierarchies = _database.GetAvailableHierarchies(cmbDataDefinition.SelectedValue.ToString()).Copy();//Calls SP
    cmbHierarchies.DataSource = GetDisplayTable(hierarchies);
    cmbHierarchies.ValueMember = "guid";
    cmbHierarchies.DisplayMember = "ObjectLogicalName";
    ...
    private IEnumerable GetDisplayTable(DataTable tbl)
    {
        yield return new { ObjectLogicalName = string.Empty, guid = Guid.Empty };
        foreach (DataRow row in tbl.Rows)
            yield return new { ObjectLogicalName = row["ObjectLogicalName"].ToString(), guid = (Guid)row["guid"] };
    }
