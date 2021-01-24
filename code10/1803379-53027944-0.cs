        public class MaskableAuditSerializer : IAuditSerializer, ITransientDependency
        {
            private readonly IAuditingConfiguration _configuration;
            public MaskableJsonNetAuditSerializer(IAuditingConfiguration configuration)
            {
                _configuration = configuration;
            }
            public string Serialize(object obj)
            {
                var options = new JsonSerializerSettings
                {
                    ContractResolver = new MaskableAuditingContractResolver(_configuration.IgnoredTypes)
                };
                return JsonConvert.SerializeObject(obj, options);
            }
        }
