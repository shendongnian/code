    private ObservableCollection<DataItem> method<T, V>(DataTable dt, SeriesItem seriesItem, FilterValues filter, ObservableCollection<DataItem> chart, Func<V, int> convertV)
        {
            var result = from t in dt.AsEnumerable()
                         group t by new { type = t.Field<T>(seriesItem.LabelMapping).ToString().ToUpper() } into g
                         orderby g.Key.type
                         select new
                         {
                             Item_Type = g.Key.type.ToString(),
                             Amount = seriesItem.IsSum ? g.Sum(s => convertV(s.Field<V>(seriesItem.ValueMapping))) : g.Count()
                         };
