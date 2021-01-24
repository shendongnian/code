    public static T MaxBy<T, TKey>(this IEnumerable<T> src, Func<T, TKey> keySelector) => src.Aggregate((a, b) => Comparer<TKey>.Default.Compare(keySelector(a), keySelector(b)) > 0 ? a : b);
    var ans = dt.AsEnumerable()
                .GroupBy(r => new {
                    Tool = r.Field<string>("Tool"),
                    Plate = r.Field<string>("Plate"),
                    Lot = r.Field<string>("Lot"),
                    Time1 = r.Field<DateTime>("Time1"),
                    Tool2 = r.Field<string>("Tool2"),
                    Time2 = r.Field<DateTime>("Time2"),
                    Recipe = r.Field<string>("Recipe"),
                    Row = r.Field<Int16>("Row")
                })
                .Select(rg => rg.MaxBy(r => r.Field<Int32>("FileID")))
                .CopyToDataTable();
