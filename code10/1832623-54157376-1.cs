    @using (Html.BeginForm("Index", "Account"))
    {
      for (int i = 0; i < Model.Items.Count; i++)
      {
        @Html.TextBoxFor(m => Model.Items[i].Prop1)
        @Html.TextBoxFor(m => Model.Items[i].Prop2)
        @Html.TextBoxFor(m => Model.Items[i].Prop3)
      }
    }
