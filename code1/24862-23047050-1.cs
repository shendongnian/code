    @Html.DropDownListFor(m => m.Category, Model.Category.ToSelectList(new Dictionary<int, string>() { 
              { 1, ContactResStrings.FeedbackCategory }, 
              { 2, ContactResStrings.ComplainCategory }, 
              { 3, ContactResStrings.CommentCategory },
              { 4, ContactResStrings.OtherCategory }
          }), new { @class = "form-control" })
    @Html.ValidationMessageFor(m => m.Category)
