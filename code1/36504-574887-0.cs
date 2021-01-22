    public static class WebUtil
    {
        public static T GetValue<T>(string key, StateBag stateBag, T defaultValue)
        {
            object o = stateBag[key];
            return o == null ? defaultValue : (T)o;
        }
    }
