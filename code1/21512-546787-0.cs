        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string abc = ((GridView)sender).DataKeys[e.Row.RowIndex].Value.ToString();
            e.Row.Attributes["onClick"] = "location.href='Default.aspx?id=" + abc + "'";
           
        }
    }
