    {
        HtmlTable table = new HtmlTable();
        HtmlTableRow row = new HtmlTableRow();
        int btnIndex = 0;
        foreach(XmlNode item in IDList)
        {
            LinkButton btn = new LinkButton();
            btn.Text = item.InnerText;
            btn.Click += new EventHandler(btn_Click);
            btn.ID = "Btn_Page" + btnIndex.ToString();
            HtmlTableCell cell = new HtmlTableCell();
            cell.Controls.add(btn);
            row.cells.add(cell);
        }
        table.rows.add(row);
    }
    protected void Btn_Page_0(object sender, EventArgs e)
    {
        whatever eventhandler code
    }  
  
