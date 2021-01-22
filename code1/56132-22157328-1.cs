        public static void IfNotNull<T>(this T obj, Action<T> action, Action actionIfNull = null) where T : class {
            if(obj != null) {
                action(obj);
            } else if ( actionIfNull != null ) {
                actionIfNull();
            }
        }
