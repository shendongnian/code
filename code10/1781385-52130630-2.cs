        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var psObj = (PSObject)value;
            writer.WriteStartObject();
            var resolver = serializer.ContractResolver as DefaultContractResolver;
            var strategy = (resolver == null ? null : resolver.NamingStrategy) ?? new DefaultNamingStrategy();
            foreach (var prop in psObj.Properties)
            {
                //Probably we shouldn't try to serialize a property that can't be read.
                //https://docs.microsoft.com/en-us/dotnet/api/system.management.automation.pspropertyinfo.isgettable?view=powershellsdk-1.1.0#System_Management_Automation_PSPropertyInfo_IsGettable
                if (!prop.IsGettable)
                    continue;
                writer.WritePropertyName(strategy.GetPropertyName(prop.Name, false));
                serializer.Serialize(writer, prop.Value);
            }
            writer.WriteEndObject();
        }
