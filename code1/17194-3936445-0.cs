    public static class NotifyPropertyChangeReactiveExtensions
    {
        // Returns the values of property (an Expression) as they change, 
        // starting with the current value
        public static IObservable<TValue> GetPropertyValues<TSource, TValue>(
            this TSource source, Expression<Func<TSource, TValue>> property)
            where TSource : INotifyPropertyChanged
        {
            MemberExpression memberExpression = property.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException(
                    "property must directly access a property of the source");
            }
            string propertyName = memberExpression.Member.Name;
            Func<TSource, TValue> accessor = property.Compile();
            return source.GetPropertyChangedEvents()
                .Where(x => x.EventArgs.PropertyName == propertyName)
                .Select(x => accessor(source))
                .StartWith(accessor(source));
        }
        // This is a wrapper around FromEvent(PropertyChanged)
        public static IObservable<IEvent<PropertyChangedEventArgs>>
            GetPropertyChangedEvents(this INotifyPropertyChanged source)
        {
            return Observable.FromEvent<PropertyChangedEventHandler, 
                PropertyChangedEventArgs>(
                h => new PropertyChangedEventHandler(h),
                h => source.PropertyChanged += h,
                h => source.PropertyChanged -= h);
        }
    }
