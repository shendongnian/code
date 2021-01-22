    public TableRow DTHeader { get; set; }
    protected override void OnInit(EventArgs e)
    {
        tblCollection.Rows.Add(DTHeader);
        base.OnInit(e);
    }
