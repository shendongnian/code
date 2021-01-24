    @{
        List<SelectListItem> QuestionType = new List<SelectListItem>();
        QuestionType.Add(new SelectListItem
             {
                 Text = "SingleLineTextBox",
                 Value = "SingleLineTextBox"
             });
        QuestionType.Add(new SelectListItem
             {
                 Text = "MultiLineTextBox",
                 Value = "MultiLineTextBox",
                 Selected = true
             });
        QuestionType.Add(new SelectListItem
             {
                 Text = "YesOrNo",
                 Value = "YesOrNo"
             });
                 QuestionType.Add(new SelectListItem
             {
                 Text = "SingleSelect",
                 Value = "SingleSelect"
             });
                 QuestionType.Add(new SelectListItem
             {
                 Text = "MultiSelect",
                 Value = "MultiSelect"
             });
    }
    @Html.DropDownList("DDlDemo", new SelectList(QuestionType, "Value", "Text"))
