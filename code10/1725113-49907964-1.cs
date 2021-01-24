    public class SOOrderEntryExt : PXGraphExtension<SOOrderEntry>
    {
        public virtual void SOOrder_TestField_FieldSelecting(PXCache sender,PXFieldSelectingEventArgs e)
        {
            if(e.Row!=null)
            {
                List<string> values = new List<string>();
                values.AddRange(new []{ "First","Second"});
                SOOrder row = (SOOrder)e.Row;
                PXStringListAttribute.SetList<SOOrderExt.testField>(sender, row, values.ToArray(), values.ToArray());
            }
        }
    }
