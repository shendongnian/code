    public static IEnumerable<Control> GetDeepControlsByType<T>(this Control control)
    {
       return control.Controls
                     .Where(c => c is T)
                     .Concat(control.Controls
                                    .SelectMany(c =>c.GetDeepControlsByType2<T>()));
    }
