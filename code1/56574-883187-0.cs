    public Question UpdateQuestion(Question newQuestion)
        {
            using (var context = new KodeNinjaEntitiesDataContext())
            {
                var question = (from q in context.Questions where q.QuestionId == newQuestion.QuestionId select q).SingleOrDefault();
                UpdateFields(newQuestion, question);
                context.SubmitChanges();                
                return question;
            }
        }
        private static void UpdateFields(Question newQuestion, Question oldQuestion)
        {
            if (newQuestion != null && oldQuestion != null)
            {
                oldQuestion.ReadCount = newQuestion.ReadCount;
                oldQuestion.VotesCount = newQuestion.VotesCount;
                .....and so on and so on.....
            }
        }
