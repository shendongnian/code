    public class DataGridRowDef : DynamicObject
        {
            private readonly object[] _columnData;
            private readonly IList<DataGridColumnDef> _columns;
    
            public static object GetDefault(Type type)
            {
                if (type.IsValueType)
                {
                    return Activator.CreateInstance(type);
                }
                return null;
            }
    
            public override IEnumerable<string> GetDynamicMemberNames()
            {
                return _columns.Select(c => c.Name).Union(base.GetDynamicMemberNames());
            }
    
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                var columnNames = _columns.Select(c => c.Name).ToList();
                if(columnNames.Contains(binder.Name))
                {
                    var columnIndex = columnNames.IndexOf(binder.Name);
                    result = _columnData[columnIndex];
                    return true;
                }
                return base.TryGetMember(binder, out result);
            }
    
            public DataGridRowDef(IEnumerable<DataGridColumnDef> columns, object[] columnData = null)
            {
                _columns = columns.ToList() ?? throw new ArgumentNullException(nameof(columns));
                if (columnData == null)
                {
                    _columnData = new object[_columns.Count()];
                    for (int i = 0; i < _columns.Count(); ++i)
                    {
                        _columnData[i] = GetDefault(_columns[i].DataType);
                    }
                }
                else
                {
                    _columnData = columnData;
                }
            }
        }
