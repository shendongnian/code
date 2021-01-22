        public static Func<TParam1, TParam2, TReturn> Memoize<TParam1, TParam2, TReturn>(Func<TParam1, TParam2, TReturn> func)
        {
            var map = new Dictionary<Tuple<TParam1, TParam2>, TReturn>();
            return (param1, param2) =>
            {
                var key = Tuple.Create(param1, param2);
                TReturn result;
                if (!map.TryGetValue(key, out result))
                {
                    result = func(param1, param2);
                    map.Add(key, result);
                }
                return result;
            };
        }
