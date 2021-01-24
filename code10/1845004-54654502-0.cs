    public class Foo
    {
        public string UserGid {get; set;}
        
        [Remote(action: "IsUserGuidEquals", controller: "Validation",AdditionalFields = "UserGid", ErrorMessage = "UserId are equals! Please select different one!")]
        public string SubstituteUserGid {get; set;}
    }
