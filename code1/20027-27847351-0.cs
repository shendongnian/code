    protected void GridViewResults_OnRowDataBound(object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.Header) {
            e.Row.TableSection = TableRowSection.TableHeader;
        }
    }
