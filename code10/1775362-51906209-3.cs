    public static class ExtensionMethods
    {
        static public int IndexOf<T>(this IEnumerable<T> source, Func<T,bool> func)
        {
            return source.TakeWhile( item => !func(item) ).Count();
        }
    {
    var index = DataGrid.ItemsSource.Cast<Item>().IndexOf( i => i.Code == code );
 
