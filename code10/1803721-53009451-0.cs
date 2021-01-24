       class Program
    {
        static void Main(string[] args)
        {
            //SumValues(
            //ExScore.Tables[0].Rows[i]["CAT2"].ToString(),
            //ExScore.Tables[0].Rows[i]["CAT3"].ToString(),
            //ExScore.Tables[0].Rows[i]["EXAM"].ToString()
            //);
           Console.WriteLine(SumValues("100,32", "100,08", "100,10",null));
           Console.WriteLine(SumValues("abcsdf", "ba123", "100,10", null));
           Console.WriteLine(SumValues("100,32", "100,08", "100,10", null));
           Console.ReadLine();
        }
        //simple function that will try to sum any number of strings you pass
        public static double SumValues(params string[] values)
        {
            double sum=0;
            foreach (var item in values)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                if (IsNumeric(item))
                    sum += double.Parse(item);
            }
            return sum;
        }
        //Minimal 'error handling' function to avoid exceptions parsing strings
        public static bool IsNumeric(string s)
        {
            double output;
            return double.TryParse(s, out output);
        }
    }
