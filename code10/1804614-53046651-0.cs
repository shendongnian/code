    @model WebApplication1.Models.MyModel
    
    <form>
        @if (Model != null && Model.List != null)
        {
            for (int i = 0; i < Model.List.Count; i++)
            {
                if (Model.List[i].IsPropTrue)
                {
                    @Html.HiddenFor(model => Model.List[i].Value1)
                    @Html.HiddenFor(model => Model.List[i].Value2)
                }
            }
        }
        <button type="submit">submit</button>
    </form>
