            public static RouteValueDictionary FixListRouteDataValues(RouteValueDictionary routes)
        {
            var newRv = new RouteValueDictionary();
            foreach (var key in routes.Keys)
            {
                object value = routes[key];
                if (value is IEnumerable && !(value is string))
                {
                    int index = 0;
                    foreach (string val in (IEnumerable)value)
                    {
                        newRv.Add(string.Format("{0}[{1}]", key, index), val);
                        index++;
                    }
                }
                else
                {
                    newRv.Add(key, value);
                }
            }
            return newRv;
        }
