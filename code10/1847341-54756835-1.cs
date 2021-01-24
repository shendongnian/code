	/// <summary> 
	/// Assigns the visiblity to controls
	/// </summary>
	/// <param name="control">Represents the object passed into the callback procedure of a control in a ribbon or another user interface that can be customized by using Office Fluent ribbon extensibility. </param>
	/// <returns>A method that returns true or false if the control is visible </returns> 
	public bool GetVisible(Office.IRibbonControl control)
	{
		try
		{
			switch (control.Id)
			{
				case "TabHome":
				case "TabInsert":
				case "TabReview":
				case "TabData":
				case "TabView":
				case "TabFormulas":
				case "TabPageLayoutExcel":
				case "TabDeveloper":
				case "TabPrintPreview":
				case "TabAddIns":
				case "TabSetTableToolsExcel":
					return Properties.Settings.Default.IsRibbonVisible;
				default:
					return false;
			}
		}
		catch (Exception ex)
		{
			//ErrorHandler.DisplayMessage(ex);
			return false;
		}
	}
	/// <summary>
	/// Used for boolean controls like checkboxes and toggle buttons
	/// </summary>
	/// <param name="control"></param>
	/// <param name="pressed"></param>
	public void OnAction_Boolean(Office.IRibbonControl control, bool pressed)
	{
		try
		{
			switch (control.Id)
			{
				case "tglShowHideRibbons":
					Properties.Settings.Default.IsRibbonVisible = pressed;
					break;
			}
			ribbon.Invalidate();
		}
		catch (Exception)
		{
			//ErrorHandler.DisplayMessage(ex);
		}
	}
	/// <summary>
	/// To return the current value for boolean controls
	/// </summary>
	/// <param name="control"></param>
	/// <returns></returns>
	public bool GetPressed(Office.IRibbonControl control)
	{
		try
		{
			switch (control.Id)
			{
				case "tglShowHideRibbons":
					return Properties.Settings.Default.IsRibbonVisible;
				default:
					return true;
			}
		}
		catch (Exception)
		{
			//ErrorHandler.DisplayMessage(ex);
			return true;
		}
	}
	/// <summary>
	/// Used to update/reset the ribbon values
	/// </summary>
	public void InvalidateRibbon()
	{
		ribbon.Invalidate();
	}
