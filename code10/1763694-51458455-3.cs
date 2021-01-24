    @{ int index = 0; }
    @for (int i = 0; i < Model.questions.Count; i++)
    {
        @Html.TextBoxFor(p => Model.questions[i].QuestionText, new { style = "font-weight : bold" })
        for (int ii = 0; ii <= Model.questions[i].Answers.Count; ii++, index++)
        {
            @Html.HiddenFor(p => Model.answers[index].Id)
            @Html.TextBoxFor(p => Model.answers[index].AnswerText)
            @Html.HiddenFor(p => Model.answers[index].Question)
        }
        <hr />
    }
