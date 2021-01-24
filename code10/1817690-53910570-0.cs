    <ul>
        @{
            var optionsDataTypeId = 1068; // your datatype id
            var selectedOption = Umbraco.GetPreValueAsString(Model.Content.GetPropertyValue<int>("favoritePet"));
            foreach (var option in Umbraco.DataTypeService.GetPreValuesCollectionByDataTypeId(optionsDataTypeId).PreValuesAsDictionary.Values)
            {
                <li class="@(option.Value == selectedOption ? "chosen" : "")">@option.Value</li>
            }
        }
    </ul>
