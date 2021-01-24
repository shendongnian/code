    public class StandardResponse<T>
    {
        public JToken Result { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Version { get; set; }
        public List<T> _Result
        {
            get
            {
                if (Result.Type == JTokenType.Array)
                {
                    List<T> signInResponses = new List<T>();
                    signInResponses = Result.ToObject<List<T>>();
                    return signInResponses;
                }
                else if (Result.Type == JTokenType.Object)
                {
                    List<T> signInResponses = new List<T>();
                    signInResponses.Add(Result.ToObject<T>());
                    return signInResponses;
                }
                else
                    return new List<T>();
            }
        }
    }
