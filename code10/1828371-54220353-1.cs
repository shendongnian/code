    public class QuoteLineJsonConverter : JsonCreationConverter<QuoteLine>
    {
        protected override QuoteLine Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");
            string discriminator = jObject.GetValue("Discriminator", StringComparison.OrdinalIgnoreCase)?.Value<string>();
            if (discriminator != null)
            {
                switch (discriminator)
                {
                    case "A":
                        return new A();
                    case "B":
                        return new B();
                    default:
                        return new QuoteLine();
                }
            }
            else
            {
                return new QuoteLine();
            }
        }
    }
