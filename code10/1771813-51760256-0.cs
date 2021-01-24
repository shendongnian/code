    public class DataReader : IDataReader
    {
        public async Task<object> ReadJsonByKey(string jsonPath, string jsonKey)
        {
            // First - is it okay to have an initialization at this stage?
            var value = new object();     
    
            // Second - is this fine to have this in the scope of this method?
            using (TextReader reader = File.OpenText(jsonPath))  
            {
                // Third -  Calling Jobject that accepts new instance of JsonTextReader
                var jObject = await JObject.LoadAsync(new JsonTextReader(reader)); 
                obj = jObject.SelectToken(jsonKey);
            }
            return value;
        }
    }
