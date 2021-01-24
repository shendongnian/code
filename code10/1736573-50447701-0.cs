    private void GridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			if (e.Column.FieldName == "DesiredColumn")
			{
				// handle display logic here, this is just POC
                var row = GridView1.GetDataRow(e.RowHandle);
                var text = row["DesiredColumn"].ToString();
                
                if (text.Length > 100) {
                  e.DisplayText = text.Substring(0, 100) + "...";
                  e.Handled = true;
                }
			}
        }
    private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
		{
			ToolTipControlInfo info;
			var gv = this.GridControl1.GetViewAt(e.ControlMousePosition) as GridView;
			if (gv == null)
			{
				return;
			}
			var hInfo = gv.CalcHitInfo(e.ControlMousePosition);
			if ((e.SelectedControl is GridControl))
			{
				if (hInfo.InRowCell)
				{
					if (hInfo.Column == gv.Columns["DesiredColumn"])
					{
						var row = gv.GetDataRow(hInfo.RowHandle);
						var text = row["DesiredColumn"].ToString;
							info = new ToolTipControlInfo(this.GridControl1, text);
							e.Info = info;
					}
				}
			}
		}
