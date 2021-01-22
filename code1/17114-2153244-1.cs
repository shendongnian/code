        public static TResult WhenTrue<TResult>(this Boolean value, Func<TResult> expression) 
        {
            return value ? expression() : default(TResult);
        }
        public static TResult WhenTrue<TResult>(this Boolean value, TResult content) 
        {
            return value ? content : default(TResult);
        }
        public static TResult WhenFalse<TResult>(this Boolean value, Func<TResult> expression)
        {
            return !value ? expression() : default(TResult);
        }
        public static TResult WhenFalse<TResult>(this Boolean value, TResult content)
        {
            return !value ? content : default(TResult);
        }
