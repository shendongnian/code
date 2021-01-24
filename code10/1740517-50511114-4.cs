       private static Random s_Random = new Random();
       // Question: Let's extract question into class
       public static IEnumerable<Question> AskQuestions(IEnumerable<Question> allQuestions) {
         if (null == allQuestions)
           throw new ArgumentNullException("allQuestions");  
         // Copy of all the questions
         List<Question> availableQuestions = allQuestions.ToList(); 
         while (availableQuestions.Any()) {
           int index = s_Random.Next(availableQuestions.Count);
           yield return availableQuestions[index]; // Ask Question
           availableQuestions.RemoveAt(index);     // And Remove It
         }
       }
