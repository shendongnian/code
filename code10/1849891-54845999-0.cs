    public class ConditionsJsonConvertor : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Conditions);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Conditions condition = new Conditions();
            condition.ParamConditions = new List<ParameterCondition>();
            JToken jtoken = JToken.ReadFrom(reader);
            foreach (JProperty prop in jtoken)
            {
                ConditionType type = (ConditionType)Enum.Parse(typeof(ConditionType), prop.Value.ToString(), true);
                condition.ParamConditions.Add(new ParameterCondition()
                {
                    Condition = type,
                    ParameterName = prop.Name
                });
            }
            return condition;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Conditions conditions = (Conditions)value;
            JObject jObjs = new JObject();
            foreach (ParameterCondition pCondition in conditions.ParamConditions)
            {
                JProperty prop = new JProperty(pCondition.ParameterName, pCondition.Condition.ToString());
                jObjs.Add(prop);
            }
            jObjs.WriteTo(writer);
        }
    }
