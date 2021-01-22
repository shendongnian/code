    using System.Linq;
    using System;
    class Story { // declare type
        public DateTime PostedOn { get; set; }
        // simplified purely for convenience
        public int VotesCount { get; set; }
        public int CommentsCount { get; set; }
    }
    static class Program {
        static void Main() {
            // dummy data
            var data = new[] {
                new Story { PostedOn = DateTime.Today,
                    VotesCount = 1, CommentsCount = 2},
                new Story { PostedOn = DateTime.Today.AddDays(-1),
                    VotesCount = 5, CommentsCount = 22},
                new Story { PostedOn = DateTime.Today.AddDays(-2),
                    VotesCount = 2, CommentsCount = 0}
            };
            var ordered = data.OrderByDescending(s=>Score(s));
            foreach (var row in ordered)
            {
                Console.WriteLine(row.PostedOn);
            }
        }
    
        private static double Score(Story s) {
            DateTime now = DateTime.Now;
            TimeSpan elapsed = now.Subtract(s.PostedOn);
            double daysAgo = elapsed.TotalDays;
            // simplified purely for convenience
            return s.VotesCount + s.CommentsCount - daysAgo;
        }
    }
