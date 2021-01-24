    public void BtnAddCost_Click(object sender, EventArgs e)
    {
        var row = new HtmlTableRow() {  };
        var cell1 = new HtmlTableCell() { Height = "25px", InnerText="extra cost" };
        cell1.Attributes.Add("class", "title_kost_tbl tbl_border_bottom");
        var cell2 = new HtmlTableCell() { InnerHtml = "<input type=\"text\" id=\"rol_totaal1\" runat=\"server\" class=\"tbl_input\"/>" };
        cell1.Attributes.Add("class", "grey_bg");
        var cell3 = new HtmlTableCell() { InnerHtml = "<input type=\"text\" id=\"rol_totaal2\" runat=\"server\" class=\"tbl_input\"/>" };
        cell1.Attributes.Add("class", "grey_bg");
        var cell4 = new HtmlTableCell() { InnerHtml = "<input type=\"text\" id=\"rol_totaal3\" runat=\"server\" class=\"tbl_input\"/>" };
        cell1.Attributes.Add("class", "grey_bg");
        var cell5 = new HtmlTableCell() { InnerHtml = "<input type=\"text\" id=\"rol_totaal4\" runat=\"server\" class=\"tbl_input\"/>" };
        cell1.Attributes.Add("class", "grey_bg");
        row.Cells.Add(cell1);
        row.Cells.Add(cell2);
        row.Cells.Add(cell3);
        row.Cells.Add(cell4);
        row.Cells.Add(cell5);
        cost_tbl.Rows.Add(row);
    }
