            void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView SubGridView = e.Row.FindControl("SubGridView") as GridView;
                List<GetLogEntriesWithUsernameByParentIdResult> subLogEntries = dc.GetLogEntriesWithUsernameByParentId(((GetLogEntriesWithUsernameResult)e.Row.DataItem).logentry_id).ToList();
                if (subLogEntries.Count > 0)
                {
                    SubGridView.DataSource = subLogEntries;
                    SubGridView.DataBind();
                    (e.Row as ExtGridViewRow).ShowExpand = SubGridView.Rows.Count > 0;
                }
            }
        }
