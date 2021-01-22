     TableCell tc = new TableCell();
        HtmlGenericControl div = new HtmlGenericControl("div");
        div.Style.Add("padding-left", "5px");
        div.Style.Add("padding-right", "5px");
        div.Controls.Add(tbox);
        tc.Controls.Add(div);
        tr.Cells.Add(tc);
        tb.Rows.Add(tr);
