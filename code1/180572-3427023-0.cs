    using (var context = new QuestionAnswerContext()) {
        Answers userAnswers = new Answers();
        userAnswers.FirstName = tbxFirstName.Text;
        userAnswers.LastName = tbxLastName.Text;
        context.Answers.Insert(userAnswers);
        context.Answers.SubmitChanges();
    }
