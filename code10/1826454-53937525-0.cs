    public class SomeModel
    {
        [FromForm(Name = "SomePropertyNameToUse")]
        public string SomeProperty { get; set; }
        [FromForm(Name = "SomeOtherPropertyNameToUse")]
        public string SomeOtherProperty { get; set; }
    }
