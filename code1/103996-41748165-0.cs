     public enum SessionKey { CurrentUser, CurrentMember, CurrentChart, CurrentAPIToken, MemberBanner }
     public static class SessionCache {
        public static T Get<T>(this HttpSessionStateBase session, SessionKey key)
        {
            var value = session[key.ToString()];
            return value == null ? default(T) : (T) value;
        }
        public static void Set<T>(this HttpSessionStateBase session, SessionKey key, T item)
        {
            session[key.ToString()] = item;
        }
        public static bool contains(this HttpSessionStateBase session, SessionKey key)
        {
            if (session[key.ToString()] != null)
                return true;
            return false;
        }
        public static void clearKey(this HttpSessionStateBase session, SessionKey key)
        {
            session[key.ToString()] = null;
        }
    }
