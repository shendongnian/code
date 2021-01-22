        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        string colId="",colr="";
        colId = e.Row.Cells[1].Text;
        colr = e.Row.Cells[2].Text;
        //Label l = new Label();
        //l.BackColor=System.Drawing.Color
        if (colId.Trim() != "Color Id" && colr.Trim() != "Color Name")
        {
            TextBox t = (TextBox)e.Row.FindControl("txtColor");
            if (t != null)
            {
                t.BackColor = System.Drawing.ColorTranslator.FromHtml(colId);
                //t.BackColor.
                
            }
        }
        //}
    }
