     public static class PivotTable
        {
            public static PivotTable<TRow, TColumn, TValue> Create<TRow, TColumn, TValue>(Dictionary<TRow, Dictionary<TColumn, TValue>> dictionary)
            where TRow : IComparable, IEquatable<TRow>
            where TColumn : IComparable, IEquatable<TColumn>
            {
                return new PivotTable<TRow, TColumn, TValue>(dictionary);
            }
        }
        public class PivotTable<TRow, TColumn, TValue>
            where TRow : IComparable, IEquatable<TRow>
            where TColumn : IComparable, IEquatable<TColumn>
        {
            private readonly Dictionary<TRow, Dictionary<TColumn, TValue>> _dictionary;
    
            public PivotTable(Dictionary<TRow, Dictionary<TColumn, TValue>> dictionary)
            {
                _dictionary = dictionary;
            }
    
            public bool HasValue(TRow row, TColumn col)
            {
                return _dictionary.ContainsKey(row) && _dictionary[row].ContainsKey(col);
            }
    
            public TValue GetValue(TRow row, TColumn col)
            {
                return _dictionary[row][col];
            }
    
            public string Print()
            {
                var separator = " ";
                var padRight = 15;
    
                var rows = _dictionary.Keys;
                var columns = _dictionary.SelectMany(x => x.Value.Keys).Distinct().OrderBy(x => x).ToList();
    
                var sb = new StringBuilder();
    
                var columnsRow = new[] { "" }.ToList();
    
                columnsRow.AddRange(columns.Select(x => x.ToString()));
    
                sb.AppendLine(string.Join(separator, columnsRow.Select(x => x.PadRight(padRight))));
    
                foreach (var row in rows.OrderBy(x => x))
                {
                    sb.Append(row.ToString().PadRight(padRight)).Append(" ");
    
                    foreach (var col in columns.OrderBy(x => x))
                    {
                        var val = HasValue(row, col) ? GetValue(row, col).ToString() : default(TValue).ToString();
                        sb.Append(val.PadRight(padRight)).Append(" ");
                    }
                    sb.AppendLine();
                }
    
                return sb.ToString();
            }
    }
    
            public class Element
            {
                public DateTime TimeStamp { get; set; }
                public string Name { get; set; }
                public int Value { get; set; }
            }
     public static class Extensions
        {
            public static PivotTable<TRow, TColumn, TValue> ToPivot<TItem, TRow, TColumn, TValue>(
                this IEnumerable<TItem> source,
                Func<TItem, TRow> rowSelector,
                Func<TItem, TColumn> colSelector,
                Func<IEnumerable<TItem>, TValue> aggregatFunc
            )
                where TRow : IComparable, IEquatable<TRow>
                where TColumn : IComparable, IEquatable<TColumn>
            {
                var dic = source
                    .GroupBy(rowSelector)
                    .ToDictionary(x => x.Key, x => x.GroupBy(colSelector).ToDictionary(y => y.Key, y => aggregatFunc(y)));
    
                return PivotTable.Create(dic);
            }
    
    
  
