    public class CreateIncomingEmailCmd
    {
        [ModelBinder(Name = "body-plain")]
        public string BodyPlain { get; set; }
        [ModelBinder(Name = "body-html")]
        public string BodyHtml { get; set; }
    }
