    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlTable table = new HtmlTable();
        HtmlTableRow row = new HtmlTableRow();
        for (int loop = 1; loop < 5; loop++)
        {
            LinkButton btn = new LinkButton();
            btn.Text = "Test " + loop.ToString();
            btn.Click += new EventHandler(btn_Click);
            HtmlTableCell cell = new HtmlTableCell();
            cell.Controls.Add(btn);
            row.Cells.Add(cell);
        }
        table.Rows.Add(row);
        // Add the table to a placeholder.
        phInputs.Controls.Add(table);
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        // Do something to catch a breakpoint.
        var x = 10;
    }
