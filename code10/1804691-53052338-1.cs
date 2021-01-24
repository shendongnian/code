                var pool = new SingleNodeConnectionPool(new Uri(uris.First()));
                connectionSettings = new ConnectionSettings(pool, connection, SourceSerializer());
        private static ConnectionSettings.SourceSerializerFactory SourceSerializer()
        {
            return (builtin, settings) => new JsonNetSerializer(builtin, settings,
                () => new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter>
                    {
                        new StringEnumConverter(),
                        DiscountConverter()
                    }
                });
        }
