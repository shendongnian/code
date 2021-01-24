        @(Html.Kendo().Grid(Model) // Specify the type of the grid
            .Name("Grid")
            .CellAction(cell =>
            {
                if (cell.Column.Title.Equals("Actual Count"))
                {
                    if (cell.DataItem.edited)
                    {
                        cell.HtmlAttributes["class"] = "edited";
                    }
                }
                if (cell.Column.Title.Equals("Book vs Actual Qty"))
                {
                    if(cell.DataItem.bookVsActualCount > Convert.ToInt32(Session["MaxAlert"]) || cell.DataItem.bookVsActualCount < Convert.ToInt32(Session["MinAlert"]))
                    {
                        cell.HtmlAttributes["class"] = "OutOfBounds";
                    }
                }
                if (cell.Column.Title.Equals("Notes"))
                {
                    if (cell.DataItem.Notes != null && cell.DataItem.Notes != "")
                    {
                        cell.Text = " ";
                        cell.HtmlAttributes["class"] = "far fa-comment-alt";
                    }
                }
            })
            .Columns(columns =>
            {
                columns.Bound(c => c.createdDate).Title("Created Date");
                columns.Bound(c => c.countDate).Title("Count Date");
                columns.Bound(c => c.bookQty).Title("Book Qty");
                columns.Bound(c => c.actualCount).Title("Actual Count");
                columns.Bound(c => c.bookVsActualCount).Title("Book vs Actual Qty");
                columns.Bound(c => c.dailyDif).Title("Daily Difference Qty");
                columns.Bound(c => c.Notes).Title("Notes");
               
            })
)
