        public static string SplitNameValuePairs(object value)
        {
            string retVal = string.Empty;
            List<string> keyValuePairs = new List<string>();
            foreach (var propInfo in value.GetType().GetProperties())
            {
                keyValuePairs.Add(string.Format("{0}:{1};", propInfo.Name, propInfo.GetValue(value, null).ToString()));
            }
            retVal = string.Join("", keyValuePairs.ToArray());
            return retVal;
        }
