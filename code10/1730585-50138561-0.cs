    public class Container
    {
        public DateTime Date { get; }
        public string OfficeId { get; }
        public string Metric_Name { get; }
        // the following is when you want to add nested objects in your json
        public AContent AContent { get; }
        // ...
        public class AContent
        {
            // whatever you want
        }
        /// <summary>
        /// Creates a new object from the json.
        /// </summary>
        /// <param name="json">The json as a string.</param>
        /// <returns></returns>
        public static Container FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Container>(json);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Transforms this to a json string
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            try
            {
                return JsonConvert.SerializeObject(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
