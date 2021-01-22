    public static class INotifyPropertyChangedExtensions
    {
        public static string ToPropertyName<T>(this Expression<Func<T>> @this)
        {
            var @return = string.Empty;
            if (@this != null)
            {
                var memberExpression = @this.Body as MemberExpression;
                if (memberExpression != null)
                {
                    @return = memberExpression.Member.Name;
                }
            }
            return @return;
        }
    }
