    public class DataReaderInjection : KnownSourceValueInjection<IDataReader>
        {
            protected override void Inject(IDataReader source, object target, PropertyDescriptorCollection targetProps)
            {
                for (var i = 0; i < source.FieldCount; i++)
                {
                    var activeTarget = targetProps.GetByName(source.GetName(i), true);
                    if (activeTarget == null) continue;
    
                    var value = source.GetValue(i);
                    if (value == DBNull.Value) continue;
    
                    activeTarget.SetValue(target, value);
                }
            }
        }
