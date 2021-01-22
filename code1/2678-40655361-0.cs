    public enum FriendType  
    {
        Default,
        Audio,
        Video,
        Image
    }
    public static class EnumHelper<T>
    {
        public static T ConvertToEnum(dynamic value)
        {
            var result = default(T);
            var tempType = 0;
        
            //see Note below
            if (value != null &&
                int.TryParse(value.ToString(), out  tempType) && 
                Enum.IsDefined(typeof(T), tempType))
            {
                result = (T)Enum.ToObject(typeof(T), tempType); 
            }
            return result;
        }
    }
