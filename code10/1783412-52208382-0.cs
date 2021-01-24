    internal class Movie
    {
        public class BaseResponse
        {
            public List<Item> Search { get; set; } = new List<Item>();
            public string Response { get; set; }
        }
        public class Item
        {
            public string Title { get; set; }            
        }
    }
    public void Generate()
    {
       Movie.BaseResponse baseResponse = new Movie.BaseResponse();
       baseResponse.Response = "True!";
       baseResponse.Search.Add (new Movie.Item { Title = "Title One" }); 
       baseResponse.Search.Add (new Movie.Item { Title = "Title Two" }); 
       string response = JsonConvert.SerializeObject(baseResponse);
    }
