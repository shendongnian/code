    public class UserParams
    {
        private const int MaxPageSize = 50;
        [FromQuery] 
        public int PageNumber { get; set; } = 1;
        
        Etc
    }
