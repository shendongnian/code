        public static string ToJSONArray<T>(this IEnumerable<T> list)
        {
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(IEnumerable<T>));
            MemoryStream ms = new MemoryStream();
            s.WriteObject(ms, list);
            return GetEncoder().GetString(ms.ToArray());
        }
        public static IEnumerable<T> FromJSONArray<T>(this string jsonArray)
        {
            if (string.IsNullOrEmpty(jsonArray)) return new List<T>();
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(IEnumerable<T>));
            MemoryStream ms = new MemoryStream(GetEncoder().GetBytes(jsonArray));
            var result = (IEnumerable<T>)s.ReadObject(ms);
            if (result == null)
            {
                return new List<T>();
            }
            else
            {
                return result;
            }
        }
