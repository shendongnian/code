    public class Result
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string AuthorName { get; set; }
    }
    connection.Query<Result>("SELECT B.Title,B.Description,B.Price,A.AuthorName FROM Author A INNER JOIN Book B on A.AuthorId = B.Authorid");
