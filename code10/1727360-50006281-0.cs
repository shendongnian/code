    public class ClaimSerializationProvider : IBsonSerializationProvider
    {
        /// <summary>
        /// <see cref="IBsonSerializationProvider.GetSerializer(Type)"/>
        /// </summary>
        public IBsonSerializer GetSerializer(Type type)
        {
            // We only provide a custom serializer for Claim
            if (type == typeof(Claim))
            {
                return new MongoClaimSerializer();
            }
            return null;
        }
    }
