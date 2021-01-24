    public class RootObject{
       public string commonName { get; set; }
       public string processorID { get; set; }
    }
    public class API_Response
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public RootObject[] ResponseData { get; set; }
    }
    API_Response r = JsonConvert.DeserializeObject<API_Response>(response);
