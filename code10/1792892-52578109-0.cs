         @for (int i = 0; i < Model.CheckBoxTag.Count; i++)
            {
                // New!
                @Html.HiddenFor(model => model.CheckBoxTag[i].Id)
                @if (Model.CheckBoxTag[i].TagTypeName == "test1")
                {
                        ...
                }
            }
