        public static List<T> CreateDynamicList<T>()
        {
            Type typeParameterType = typeof(T);
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(typeParameterType);
            return (List<T>)Convert.ChangeType(constructedListType, typeof(T));
        }
