    @model object 
    
    @{  int size = 10; int maxLength = 100; }
    @if (ViewData["size"] != null) {
        Int32.TryParse((string)ViewData["size"], out size); 
    } 
    
    @if (ViewData["maxLength"] != null) {
        Int32.TryParse((string)ViewData["maxLength"], out maxLength); 
    }
    @Html.TextBox("", Model, new { Size = size, MaxLength = maxLength})
