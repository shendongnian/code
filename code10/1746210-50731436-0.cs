    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace GetCustomAttribute
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                var sb = new StringBuilder();
    
                sb.AppendLine(@"
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
                            currentProperty = reader.Value.ToString();");
                
                var props = typeof(PurchaseOrder).GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(IdAttribute)));
                foreach (var prop in typeof(PurchaseOrder).GetProperties())
                {
                    var attribute = prop.GetCustomAttributes(typeof(IdAttribute), false).SingleOrDefault() as IdAttribute;
                    if (attribute != null)
                    {
                        var s = $"if (reader.TokenType == JsonToken.String && currentProperty == \"{attribute.Id}\") purchaseOrder.{prop.Name} = reader.Value.ToString();";
                        sb.AppendLine(s);
                    }
                }
    
                sb.Append("}}}}}}");
    
                File.WriteAllText("PurchaseOrderParser.cs", sb.ToString());
            }
        }
    
        class PurchaseOrder
        {
            [Id("id")]
            public string Id { get; set; }
    
            [Id("name")]
            public string Name { get; set; }
        }
    
        class IdAttribute : Attribute
        {
            public string Id { get; set; }
    
            public IdAttribute(string id) => Id = id;
        }
    }
