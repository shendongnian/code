     @model List<QuestionsTest.Models.QuestionModel>    
        <form method="post">
          <table class="table">
            @for (int i = 0; i < Model.Count; i++)
            {
              <tr>
                <td colspan="2">
                  @Html.HiddenFor(model => Model[i].Id, new { @class = "form-control" })
                  <b>  @Html.TextBoxFor(model => Model[i].Question, new { @class = "form- 
                  control" })</b>
                </td>
              </tr>
        
              for (int j = 0; j < Model[i].SubQuestions.Count; j++)
              {
                <tr>
                  <td>
                    @Html.HiddenFor(model => Model[i].SubQuestions[j].Id, new { @class = 
                    "form-control" })
                    @Html.HiddenFor(model => Model[i].SubQuestions[j].ParentQuestionId, new { 
                    @class = "form-control" })
                    @Html.TextBoxFor(model => Model[i].SubQuestions[j].SubQuestion1, new { 
                    @class = "form-control" })
                  </td>
                  <td>
                    @for (int k = 0; k < Model[i].Options.Count; k++)
                    {
                      @Html.RadioButtonFor(model => Model[i].Options[k].QuestionOption, 
                      Model[i].Options[k].QuestionOption)@Model[i].Options[k].QuestionOption
                    }
        
                  </td>
                </tr>
              }
        
            }
          </table>
          <input class="btn-block btn-success" type="submit" value="Update" />
