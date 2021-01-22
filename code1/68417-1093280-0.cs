    public static Action<DataGrid, DataGridCell, bool> CreateSelectRowMethod(bool allowExtendSelect, bool allowMinimalSelect)
    {
    var selectCellMethod = typeof(DataGrid).GetMethod("HandleSelectionForCellInput", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    ParameterExpression dataGrid = Expression.Parameter(typeof(DataGrid), "dataGrid");
    ParameterExpression paramCell = Expression.Parameter(typeof(DataGridCell), "cell");
    ParameterExpression paramStartDragging = Expression.Parameter(typeof(bool), "startDragging");
    var paramAllowsExtendSelect = Expression.Constant(allowExtendSelect, typeof(bool));
    var paramAllowsMinimalSelect = Expression.Constant(allowMinimalSelect, typeof(bool));
    var call = Expression.Call(dataGrid, selectCellMethod, paramCell, paramStartDragging, paramAllowsExtendSelect, paramAllowsMinimalSelect);
    return (Action<DataGrid, DataGridCell, bool>)Expression.Lambda(call, dataGrid, paramCell, paramStartDragging).Compile();
    }
