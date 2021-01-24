        static void Main(string[] args)
        {
            List<string> askQuestions = Questions();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(askQuestions[i]);
            }
        }
        static List<string> Questions()
        {
            List<string> question = new List<string>();
            question.Add("q1");
            question.Add("q2");
            //etc
            return question;
        }
