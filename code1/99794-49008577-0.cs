        public static T2[] ToValueArray<T1, T2>(this Dictionary<T1, T2> value)
        {
            var values = new T2[value.Values.Count];
            value.Values.CopyTo(values, 0);
            return values;
        }
