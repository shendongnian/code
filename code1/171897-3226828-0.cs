    private void pivotGridControl1_CustomFieldSort(object sender, DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs e) {
        if(e.Field.FieldName == "Name") {
            int value1 = Convert.ToInt32(e.GetListSourceColumnValue(e.ListSourceRowIndex1, "ID"));
            int value2 = Convert.ToInt32(e.GetListSourceColumnValue(e.ListSourceRowIndex2, "ID"));
            e.Result = Comparer.Default.Compare(value1, value2);
            if(e.SortOrder == DevExpress.XtraPivotGrid.PivotSortOrder.Descending)
                e.Result = -e.Result;
            e.Handled = true;
        }
    }
