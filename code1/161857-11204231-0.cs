    private object[] DatagridBuffer(Person p)
    {
        object[] buffer = new object[1];
        buffer[0] = p.FirstName;
        buffer[1] = p.LastName;
        return buffer;
    {
    public void ListPeople() 
    {
        List<DatagridViewRow> rows = new List<DataGridViewRow>();
        Dictionary<int, Person> list = SqlUtilities.Instance.InstallationList();
        int index = 0;
        foreach (Person p in list.Values) {
            rows.Add(new DataGridViewRow());
            rows[index].CreateCells(datagrid, DatagridBuffer(p));
            index += 1;
        }
        UpdateDatagridView(rows.ToArray());
    }
    public delegate void UpdateDatagridViewDelegate(DataGridViewRow[] list);
    public void UpdateDatagridView(DataGridViewRow[] list)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(
                 new UpdateDatagridViewDelegate(UpdateDatagridView), 
                 new object[] { list }
            );
        }
        else
        {
            datagrid.Rows.AddRange(list);
        }
    }
