	if (IsPostBack)
	{
		ListViewItem lvi;
		for (int i = 0; i < lvw.Items.Count; i++)
		{
			lvi = lvw.Items[i];
			HtmlTableCell tdCell = (HtmlTableCell)lvi.FindControl("tdCell");
			
			DataTable dt = (DataTable)Data;
			DataRow[] dr = dt.Select("[Selection Criteria]");
			int idx = 0;
			foreach (DataRow d in dr)
			{
				TextBox txtRemark = new TextBox();
				txtRemark.ID = "txtRemark_" + (i+1).ToString() + "_" + idx.ToString();
				idx++;
				tdCell.Controls.Add(txtRemark);
			}
		}
	}
