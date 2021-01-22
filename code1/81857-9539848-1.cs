	public static DataRow GridViewRowToDataRow(GridViewRow gvr)
	{
		object di = null;
		DataRowView drv = null;
		DataRow dr = null;
		if (gvr != null) {
			di = gvr.DataItem as System.Object;
			if (di != null) {
				drv = di as System.Data.DataRowView;
				if (drv != null) {
					dr = drv.Row as System.Data.DataRow;
				}
			}
		}
		return dr;
	}
	public static DataRow GridViewRowEventArgsToDataRow(GridViewRowEventArgs e)
	{
		GridViewRow gvr = null;
		object di = null;
		DataRowView drv = null;
		DataRow dr = null;
		if (e.Row.RowType == DataControlRowType.DataRow) {
			gvr = e.Row as System.Web.UI.WebControls.GridViewRow;
			dr = Helpers.GridViewRowToDataRow(gvr);
		}
		return dr;
	}
