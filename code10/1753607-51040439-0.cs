    class RuleConditionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(RuleCondition));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var @operator = (Operator)jo["Operator"].Value<int>();
            var field = jo["Field"].Value<string>();
            var isPercent = (PercentOrAbsolute)jo["ValueExpression"]["IsPercent"].Value<int>();
            var rigthOperator = (RightOperator)jo["ValueExpression"]["Operator"].Value<int>();
            var value = jo["ValueExpression"]["Value"].Value<double>();
            var relativeToBaseline = jo["ValueExpression"]["RelativeToBaseline"].Value<bool>();
            RuleCondition result = new RuleCondition(field, @operator, new RightValueExpression(relativeToBaseline, rigthOperator, value, isPercent));
            return result;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
