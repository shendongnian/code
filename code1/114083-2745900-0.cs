    class Result
        {
            private Result()
            {
            }
            public static Result OK = new Result();
            public static Result Error = new Result();
            public static implicit operator bool(Result result)
            {
                return result == OK;
            }
            public static implicit operator Result( bool b)
            {
                return b ? OK : Error;
            }
        }
