    //using System.ComponentModel;
    //using DevExpress.XtraPivotGrid;
    var properties = TypeDescriptor.GetProperties(typeof(Dto));
    foreach (PivotGridField f in pivotGridControl.Fields)
        f.Caption = properties[f.FieldName].DisplayName;
