    public class SOOrderEntryExt : PXGraphExtension<SOOrderEntry>
    {
        public virtual void SOLine_TestField_FieldSelecting(PXCache sender,PXFieldSelectingEventArgs e)
        {
            if(e.Row!=null)
            {
                List<string> values = new List<string>();
                values.AddRange(new[] { "First", "Second" });
                PXStringListAttribute.SetList<SOLineExt.testField>(sender, null, values.ToArray(), values.ToArray());
            }
        }
    }
