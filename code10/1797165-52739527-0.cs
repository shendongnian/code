     public class EnumAsStringSerializer : JsonSerializer
        {
            public EnumAsStringSerializer()
            {
                this.ContractResolver = new CamelCasePropertyNamesContractResolver();
                this.Converters.Add(new StringEnumConverter
                {
                    CamelCaseText = true,
                });
            }
        }
