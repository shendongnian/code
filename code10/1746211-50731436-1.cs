    namespace GetCustomAttribute
    {
        public static class PurchaseaOrderParser
        {
            public static void Parse(string jsonString, PurchaseOrder purchaseOrder)
            {
    
                var reader = new JsonTextReader(new StringReader(jsonString));
    
                var currentProperty = string.Empty;
    
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.TokenType == JsonToken.PropertyName)
                            currentProperty = reader.Value.ToString();
    if (reader.TokenType == JsonToken.String && currentProperty == "id") purchaseOrder.Id = reader.Value.ToString();
    if (reader.TokenType == JsonToken.String && currentProperty == "name") purchaseOrder.Name = reader.Value.ToString();
    }}}}}}
