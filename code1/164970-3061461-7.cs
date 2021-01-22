    public class DataReaderInjection : KnownSourceValueInjection<IDataReader>
            {
                protected override void Inject(IDataReader source, object target, PropertyDescriptorCollection targetProps)
                {
                    var columns = source.GetSchemaTable().Columns;
                    for (var i = 0; i < columns.Count; i++)
                    {
                        var c = columns[i];
    
                        var targetPropName = c.ColumnName; //default is the same as columnName
    
                        if (c.ColumnName == "Foo") targetPropName = "TheTargetPropForFoo";
                        if (c.ColumnName == "Bar") targetPropName = "TheTargetPropForBar";
                        //you could also create a dictionary and use it here
    
                        var targetProp = targetProps.GetByName(targetPropName);
                        //go to next column if there is no such property in the target object
                        if (targetProp == null) continue;
                        
                        targetProp.SetValue(target, columns[c.ColumnName]);
                    }
                }
            }
