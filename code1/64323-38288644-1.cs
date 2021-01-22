     @model MVCLearning.Models.BookViewModel
    @{
      using (Html.BeginForm("Submit", "Dynamic"))
       {
        if (Model.Count > 0 && Model != null)
        {
            for (int i = 0; i < 5; i++)
            {
                <div id="div_@i">
                    @Html.TextBoxFor(m => Model.Books[i].Title)
                </div>
            }
            <input type="submit" value="Submit" />
        }
    }
    } 
