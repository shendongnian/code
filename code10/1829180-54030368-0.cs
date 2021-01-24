    public class PaginationParameters
    {
        [FromQuery(Name = "page")]
         public int PageNumber { get; set;}
        [FromQuery(Name = "size")]
        public int PageSize { get; set;}
    }
