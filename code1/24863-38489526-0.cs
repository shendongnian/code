    @Html.DropDownList("RefType", new SelectList(Enum.GetValues(typeof(WebAPIApp.Models.RefType))), " Select", new { @class = "form-control" })
    
    public enum RefType
        {
            Web = 3,
            API = 4,
            Security = 5,
            FE = 6
        }
    
        public class Reference
        {
            public int Id { get; set; }
            public RefType RefType { get; set; }
        }
