    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = (DataService.User)e.Row.DataItem;
                e.Row.Cells[0].Text = string.Format(@"<img src='images/friend.png' onclick='javascript:ShowDetails(""{0}"")' />", data.UserID);
            }
        }
