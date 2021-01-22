    public static class SearchResultFactory
    {
        const BindingFlags nonPublicInstance = BindingFlags.NonPublic | BindingFlags.Instance;
        const BindingFlags publicInstance = BindingFlags.Public | BindingFlags.Instance;
        public static SearchResult Construct<T>(T anonInstance)
        {
            var searchResult = GetUninitializedObject<SearchResult>();
            SetPropertiesFieled(searchResult);
            var dictionary = (IDictionary)searchResult.Properties;
            var type = typeof(T);
            var propertyInfos = type.GetProperties(publicInstance);
            foreach (var propertyInfo in propertyInfos)
            {
                var value = propertyInfo.GetValue(anonInstance,null);
                var propertyCollection = GetUninitializedObject<ResultPropertyValueCollection>();
                var innerList = GetInnerList(propertyCollection);
                if (propertyInfo.PropertyType.IsArray)
                {
                    var stringArray = (String[])value;
                    foreach (var subValue in stringArray)
                    {
                        innerList.Add(subValue);
                    }
                }
                else
                {
                    innerList.Add(value);
                }
                var lowerKey = propertyInfo.Name.ToLower(CultureInfo.InvariantCulture);
                dictionary.Add(lowerKey, propertyCollection);
            }
            return searchResult;
        }
        static ArrayList GetInnerList(object resultPropertyCollection)
        {
            var propertyInfo = typeof(ResultPropertyValueCollection).GetProperty("InnerList", nonPublicInstance);
            return (ArrayList) propertyInfo.GetValue(resultPropertyCollection, null);
        }
        static void SetPropertiesFieled(SearchResult searchResult)
        {
            var propertiesFiled = typeof(SearchResult).GetField("properties", nonPublicInstance);
            propertiesFiled.SetValue(searchResult, GetUninitializedObject<ResultPropertyCollection>());
        }
        static T GetUninitializedObject<T>()
        {
            return (T) FormatterServices.GetUninitializedObject(typeof(T));
        }
    }
