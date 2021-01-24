        public static T SetThrow<T>(List<object> args) where T : Throw, new()
        {
            return new T
            {
                speed = (double)args[0],
                accurency = (double)args[1]
            };
        }
