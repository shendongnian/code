    @model WebApplication2.Models.User
    
    @using (Html.BeginForm("SaveUser", "Home", FormMethod.Get))
    {
        @Html.LabelFor(m => m.Username)
        @Html.EditorFor(m => m.Username) <br />
    
        @Html.LabelFor(m => m.Child.Name)
        @Html.EditorFor(m => m.Child.Name) <br/>
    
        @Html.LabelFor(m => m.Child.Toy.ToyName)
        @Html.EditorFor(m => m.Child.Toy.ToyName) <br />
    
        <input type="submit" />
    
    }
