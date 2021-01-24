    var properties = System.ComponentModel.TypeDescriptor.GetProperties(typeof(Dto));
    foreach (System.ComponentModel.PropertyDescriptor p in properties)
    {
        pivotGridControl.Fields[p.Name].Caption = p.DisplayName;
    }
