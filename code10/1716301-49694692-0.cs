    @model List<SettingsModel>
    
    @using (Html.BeginForm())
    {
        for (int i = 0; i < Model.Count; i++)
        {
            <div>
                @Html.TextBoxFor(x => Model[i].CarIsScrapped)
            </div>
        }
        <input type="submit" value="Save" />
    }
