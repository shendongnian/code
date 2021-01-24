    public class Student
    {
        public string Name { get; set; }
        public int Course1Score { get; set; }
        public int Course2Score { get; set; }
        public int FinalExamScore { get; set; }
        public double AggregateScore => Course1Score * .3 + Course2Score * .3 +
                                        FinalExamScore * .4;
    }
