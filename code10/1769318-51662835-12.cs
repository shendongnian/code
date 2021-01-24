        public static class JsonBase<T> where T: BaseData<T> 
        {
            public static List<T> ReturnResultsList(string json)
            {
                var returnData = JsonConvert.DeserializeObject<BaseData<T>>(json);
                return returnData.results;
            }
            public static  string ReturnMetaData(string json)
            {
                var returnData = JsonConvert.DeserializeObject<BaseData<T>>(json);
                return returnData.metadata;
            }
        }
