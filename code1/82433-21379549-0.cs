    public static class INotifyPropertyChangedExtensions
    {
        public static bool SetPropertyAndNotify<T>(this INotifyPropertyChanged sender,
                   PropertyChangedEventHandler handler, ref T field, T value, 
                   [CallerMemberName] string propertyName = "",
                   EqualityComparer<T> equalityComparer = null)
        {
            bool rtn = false;
            var eqComp = equalityComparer ?? EqualityComparer<T>.Default;
            if (!eqComp.Equals(field,value))
            {
                field = value;
                rtn = true;
                if (handler != null)
                {
                    var args = new PropertyChangedEventArgs(propertyName);
                    handler(sender, args);
                }
            }
            return rtn;
        }
    }
