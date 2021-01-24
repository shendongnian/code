    namespace Grades
    {
        public class GradeCalculator
        {
            public string LetterGrade
            {
                get
                {
                    string result;
                    if (RoundResult(GradeStatistics.AverageGrade) >= 90)
                    {
                        result = "A";
                    }
                    else if (RoundResult(GradeStatistics.AverageGrade) >= 80)
                    {
                        result = "B";
                    }
                    else if (RoundResult(GradeStatistics.AverageGrade) >= 70)
                    {
                        result = "C";
                    }
                    else
                    {
                        result = "F";
                    }
                    return result;
                }
            }
    
            private double RoundResult(double result)
            {
                double r;
                r = Math.Round(result);
                return r;
            }
        }
    
        public static class GradeStatistics
        {
            public static float AverageGrade = 50;
            public static float HighestGrade = 78;
            public static float LowestGrade = 11;
        }
    }
