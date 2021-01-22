    static class WpfUtils
    {
        public static DependencyProperty RegisterDependencyPropertyWithCallback<TObject, TProperty>(string propertyName, Func<TObject, Action<TProperty, TProperty>> getOnChanged)
            where TObject : DependencyObject
        {
            return DependencyProperty.Register(
                propertyName,
                typeof(TProperty),
                typeof(TObject),
                new PropertyMetadata(new PropertyChangedCallback((d, e) =>
                    getOnChanged((TObject)d)((TProperty)e.OldValue, (TProperty)e.NewValue)
                ))
            );
        }
    }
