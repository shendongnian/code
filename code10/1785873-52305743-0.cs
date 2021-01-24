        public class ResultDto<T> where T : class
    {
        public ResultDto(string status, IList<T> data)
        {
            Status = status;
            Data = data;
        }
        public string Status { get; set; }
        public IList<T> Data { get; set; }
    }
