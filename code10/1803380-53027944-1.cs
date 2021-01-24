        public class MaskableAuditingContractResolver : AuditingContractResolver
        {
            public MaskableAuditingContractResolver(List<Type> ignoredTypes)
                : base(ignoredTypes)
            {
            }
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                if (member.IsDefined(typeof(MaskedAuditedAttribute)))
                {
                    property.ValueProvider = new MaskedValueProvider();
                }
                return property;
            }
        }
