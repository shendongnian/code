        protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            TableRow tr = (TableRow)e.Row.Cells[0].Controls[0].Controls[0];
            if (tr.Cells[1] != null && (((tr.Cells[1]).Controls[0]) is LinkButton))
            {
                LinkButton btnPrev = (LinkButton)(tr.Cells[1]).Controls[0];
                if (btnPrev.Text == "...")
                {
                    (((tr.Cells[1]).Controls[0]) as LinkButton).Text = "<";
                }
            }
            if (tr.Cells[tr.Cells.Count - 2] != null && (((tr.Cells[tr.Cells.Count - 2]).Controls[0]) is LinkButton))
            {
                LinkButton btnNext = (LinkButton)(tr.Cells[tr.Cells.Count - 2]).Controls[0];
                if (btnNext.Text == "...")
                {
                    (((tr.Cells[tr.Cells.Count - 2]).Controls[0]) as LinkButton).Text = ">";
                }
            }
        }
    }
