    public class Machine1ListConverter<TMachineInfo> : JsonListItemTypeInferringConverterBase<TMachineInfo> where TMachineInfo : IMachineInfo
    {
        protected override bool TryInferItemType(Type objectType, JToken json, out Type type)
        {
            var obj = json as JObject;
            if (obj != null && obj.GetValue("powerWatts", StringComparison.OrdinalIgnoreCase) != null)
            {
                type = typeof(Machine1);
                return true;
            }
            type = null;
            return false;
        }
    }
