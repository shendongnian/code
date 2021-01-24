    static class Extensions
    {
        public static T Exec<T>(this T item, Action<T> callback)
        {
            callback( item );
            return item;
        }
    }
    
    Button btn = new Button()
    {
        FontSize = 12,
        Context = "button text"
    }.Exec( b => {
        b.Click + (s,e) => ... ;
        b.DoubleClick + (s,e) => ... ;
    } )
