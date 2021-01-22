    public static class Notify {
        public static bool SetField<T>(ref T field, T value,
             PropertyChangedEventHandler handler, object sender, string propertyName)
        {
            if(!EqualityComparer<T>.Default.Equals(field,value)) {
                field = value;
                if(handler!=null) {
                    handler(sender, new PropertyChangedEventArgs(propertyName));
                }
                return true;
            }
            return false;
        }
    }
