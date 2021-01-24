    for (i = 0; i < Model.Questions.Count;i++)
    {
        ViewBag.QuestionNumber = i;
        Html.RenderPartial("_QuestionDetail", Model.Questions[i]); //Line causing error
    }
