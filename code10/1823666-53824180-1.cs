    @model YourProjectName.Project.Models.ExampleViewModel
    <div>
        @using (Html.BeginForm("Example", "YourController", FormMethod.Post))
        {
            @Html.TextBoxFor(model => model.InputOne)
            <input type="submit" value="Submit">
        }
    </div>
