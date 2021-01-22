        public static T[] ExtendArray<T> ( T[] array , uint index) where T:new()
        {
            List<T> list = new List<T>();
            list.AddRange(array);
            while (list.Count < index) {
                list.Add(new T());
            }
            return list.ToArray();
        }
