    public void Page_Load(object sender, EventArgs args) {
        List<Question> questions = this.repository.GetQuestions();
        foreach(Question question in Questions) {
            this.Controls.Add(QuestionControlFactory.CreateQuestionControl(question));
            // ... Additional wiring etc.
        }
    }
