    PotentialEmployee pe = new PotentialEmployee();
    PropertyInfo[] pi = pe.GetType().GetProperties();
    string filePath = "D:\\Questions.txt";
    using (StreamReader InterviewQuestions = new StreamReader(filePath))
    {
        for (int particularQuestion = 0; particularQuestion < TotalLines(filePath);
             particularQuestion++)
        {                    
            Console.WriteLine(InterviewQuestions.ReadLine());
            pi[particularQuestion].SetValue(pe, Console.ReadLine(), null);
            
        }
    }
