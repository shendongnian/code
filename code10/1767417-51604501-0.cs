    public struct ComboItem
    {
        public string Question;
        public int ID;
    }
    using (var Context = new ProfetusModel())
    {
        var GetQuestions = Context.Questions.Select(ques => new ComboItem { Question = ques.Question1, ID = ques.IdQues }).ToList();
        // CompoQues.ItemsSource = GetQuestions;
        CompoQues.ItemsSource = GetQuestions
        CompoQues.DisplayMemberPath = "Question";
        CompoQues.SelectedValuePath = "ID";
        CompoQues.SelectedIndex = 0;
    }
