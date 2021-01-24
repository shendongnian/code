    class QueryExpressionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(QueryExpression).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JProperty prop = JObject.Load(reader).Properties().First();
            var op = prop.Name;
            if (op == "AND" || op == "OR")
            {
                var subExpressions = prop.Value.ToObject<List<QueryExpression>>();
                return new CompositeExpression { Operator = op, SubExpressions = subExpressions };
            }
            else
            {
                var values = prop.Value.ToObject<string[]>();
                if (values.Length != 2)
                    throw new JsonException("Binary expression requires two values. Got " + values.Length + " instead: " + string.Join(",", values));
                return new BinaryExpression { Operator = op, Value1 = values[0], Value2 = values[1] };
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            QueryExpression expr = (QueryExpression)value;
            JToken array;
            if (expr is CompositeExpression)
            {
                var composite = (CompositeExpression)expr;
                array = JArray.FromObject(composite.SubExpressions);
            }
            else
            {
                var bin = (BinaryExpression)expr;
                array = JArray.FromObject(new string[] { bin.Value1, bin.Value2 });
            }
            JObject jo = new JObject(new JProperty(expr.Operator, array));
            jo.WriteTo(writer);
        }
    }
