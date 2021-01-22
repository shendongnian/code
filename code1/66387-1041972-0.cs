    protected string Table_Maker() {
        HtmlTable tbl = new HtmlTable();
        HtmlTableCell cell = new HtmlTableCell();
        HtmlTableRow row = new HtmlTableRow();
        cell.InnerText = "WhateverText";
        row.Cells.Add(cell);
        tbl.Rows.Add(row);
        StringBuilder sb = new StringBuilder();
        using( StringWriter sw = new StringWriter( sb ) ) {
            using( HtmlTextWriter tw = new HtmlTextWriter( sw ) ) {
                tbl.RenderControl( tw );
            }    
        }    
        return sb.ToString();
    }
