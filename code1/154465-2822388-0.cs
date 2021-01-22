    namespace CustomControls
    {
	public class CompositeBoundField : BoundField
	{
		protected override object GetValue(Control controlContainer)
		{
			object item = DataBinder.GetDataItem(controlContainer);
			return DataBinder.Eval(item, this.DataField);
		}
	}
	public class CompositeCheckBoxField : CheckBoxField
	{
	
		protected override object GetValue(Control controlContainer)
		{
			/*bool isChecked = false;
			if (this.DataField.ToLower() == "true")
				isChecked = true;
			object item = DataBinder.GetDataItem(controlContainer);
			return isChecked;
			*/
			object item = DataBinder.GetDataItem(controlContainer);
			return DataBinder.Eval(item, this.DataField);
		}
	}
	
