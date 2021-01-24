        public class RequestVM
        {
            [FromQuery]
            public int Draw { get; set; }
            [FromQuery]
            public int Start { get; set; }
            [FromQuery]
            public int Length { get; set; }
        }
        public class ResponseVM
        {
            public int Draw { get; set; }
            public int RecordsTotal { get; set; }
            public int RecordsFiltered { get; set; }
            public object Data { get; set; }
        }
