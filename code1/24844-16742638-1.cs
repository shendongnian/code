    @using MVCProject.Extensions
     
    @{
        var type = Nullable.GetUnderlyingType(ViewData.ModelMetadata.ModelType) ?? ViewData.ModelMetadata.ModelType;
     
        @(typeof (Enum).IsAssignableFrom(type) ? Html.EnumDropDownListFor(x => x) : Html.TextBoxFor(x => x))
    }
