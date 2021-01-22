    public static class Binder
    {
        public static void Bind(
            INotifyPropertyChanged source,
            string sourcePropertyName,
            INotifyPropertyChanged target,
            string targetPropertyName)
        {
            var sourceProperty
                = source.GetType().GetProperty(sourcePropertyName);
            var targetProperty
                = target.GetType().GetProperty(targetPropertyName);
            source.PropertyChanged +=
                (s, a) =>
                {
                    var sourceValue = sourceProperty.GetValue(source, null);
                    var targetValue = targetProperty.GetValue(target, null);
                    if (!Object.Equals(sourceValue, targetValue))
                    {
                        targetProperty.SetValue(target, sourceValue, null);
                    }
                };
            target.PropertyChanged +=
                (s, a) =>
                {
                    var sourceValue = sourceProperty.GetValue(source, null);
                    var targetValue = targetProperty.GetValue(target, null);
                    if (!Object.Equals(sourceValue, targetValue))
                    {
                        sourceProperty.SetValue(source, targetValue, null);
                    }
                };
        }
    }
