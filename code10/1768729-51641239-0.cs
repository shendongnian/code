    namespace RittensportRekenSoftware.Models
    {
        public class Results
        {
            public int team_number { get; set; }
            public List<Result> results { get; set; }
            public Results() {
                results = new List<Result>();
            }
        }
    
        public class Result
        {
            public string given_start_time { get; set; }
            public string connection_to_start { get; set; }
            public string start_kp { get; set; }
            public string stop_kp { get; set; }
            public int missed_controls { get; set; }
            public float km { get; set; }
            public List<string> gtks { get; set; }
            public Result() {
                gtks = new List<string>();
            }
        }
    }
