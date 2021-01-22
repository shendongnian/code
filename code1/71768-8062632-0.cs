    public class BetterBoundField : BoundField
    {
        protected override object GetValue(Control controlContainer)
        {
            if (DataField.Contains("."))
            {
                var component = DataBinder.GetDataItem(controlContainer);
                return DataBinder.Eval(component, DataField);
            }
            return base.GetValue(controlContainer);
        }
    }
