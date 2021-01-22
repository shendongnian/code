    	public static void BindListControl (ListControl ctl, SqlDataReader dr,
			String textColumn, String valueColumn, bool addBlankRow, string blankRowText)
		{
			ctl.Items.Clear();
			ctl.DataSource = dr;
			ctl.DataTextField = textColumn;
			ctl.DataValueField = valueColumn;
			ctl.DataBind();
			if (addBlankRow == true) ctl.Items.Insert(0, blankRowText);
		}
