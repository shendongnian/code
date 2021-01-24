    internal class SqlBotDataContext : System.Data.Entity.DbContext
    {
        public SqlBotDataContext(string connectionString)
            : base(connectionString)
        {
            System.Data.Entity.Database.SetInitializer<SqlBotDataContext>(null);
        }
    
        /// <summary>
        /// Throw if the database or SqlBotDataEntities table have not been created.
        /// </summary>
        static internal void AssertDatabaseReady()
        {
            //var connectionString = Utils.GetAppSetting(AppSettingKeys.SqlServerConnectionString);
            var connectionString = ConfigurationManager.ConnectionStrings["BotDataContextConnectionString"].ConnectionString;
            using (var context = new SqlBotDataContext(connectionString))
            {
                if (!context.Database.Exists())
                    throw new ArgumentException("The sql database defined in the connection has not been created. See https://github.com/Microsoft/BotBuilder-Azure/tree/master/CSharp");
    
                if (context.Database.SqlQuery<int>(@"IF EXISTS (SELECT * FROM sys.tables WHERE name = 'SqlBotDataEntities') 
                                                                    SELECT 1
                                                                ELSE
                                                                    SELECT 0").SingleOrDefault() != 1)
                    throw new ArgumentException("The SqlBotDataEntities table has not been created in the database. See https://github.com/Microsoft/BotBuilder-Azure/tree/master/CSharp");
            }
        }
    
        public DbSet<SqlBotDataEntity> BotData { get; set; }
    }
    public enum BotStoreType
    {
        BotConversationData = 0,
        BotPrivateConversationData = 1,
        BotUserData = 2
    }
    internal class SqlBotDataEntity : IAddress
    {
        private static readonly JsonSerializerSettings serializationSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.None,
            NullValueHandling = NullValueHandling.Ignore
        };
        internal SqlBotDataEntity() { Timestamp = DateTimeOffset.UtcNow; }
        internal SqlBotDataEntity(BotStoreType botStoreType, string botId, string channelId, string conversationId, string userId, object data)
        {
            this.BotStoreType = botStoreType;
            this.BotId = botId;
            this.ChannelId = channelId;
            this.ConversationId = conversationId;
            this.UserId = userId;
            this.Data = Serialize(data);
            Timestamp = DateTimeOffset.UtcNow;
        }
    
    
        #region Fields
    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Index("idxStoreChannelUser", 1)]
        [Index("idxStoreChannelConversation", 1)]
        [Index("idxStoreChannelConversationUser", 1)]
        public BotStoreType BotStoreType { get; set; }
        public string BotId { get; set; }
        [Index("idxStoreChannelConversation", 2)]
        [Index("idxStoreChannelUser", 2)]
        [Index("idxStoreChannelConversationUser", 2)]
        [MaxLength(200)]
        public string ChannelId { get; set; }
        [Index("idxStoreChannelConversation", 3)]
        [Index("idxStoreChannelConversationUser", 3)]
        [MaxLength(200)]
        public string ConversationId { get; set; }
        [Index("idxStoreChannelUser", 3)]
        [Index("idxStoreChannelConversationUser", 4)]
        [MaxLength(200)]
        public string UserId { get; set; }
        public byte[] Data { get; set; }
        public string ETag { get; set; }
        public string ServiceUrl { get; set; }
        [Required]
        public DateTimeOffset Timestamp { get; set; }
    
        #endregion Fields
    
        #region Methods
    
        private static byte[] Serialize(object data)
        {
            using (var cmpStream = new MemoryStream())
            using (var stream = new GZipStream(cmpStream, CompressionMode.Compress))
            using (var streamWriter = new StreamWriter(stream))
            {
                var serializedJSon = JsonConvert.SerializeObject(data, serializationSettings);
                streamWriter.Write(serializedJSon);
                streamWriter.Close();
                stream.Close();
                return cmpStream.ToArray();
            }
        }
    
        private static object Deserialize(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            using (var gz = new GZipStream(stream, CompressionMode.Decompress))
            using (var streamReader = new StreamReader(gz))
            {
                return JsonConvert.DeserializeObject(streamReader.ReadToEnd());
            }
        }
    
        internal ObjectT GetData<ObjectT>()
        {
            return ((JObject)Deserialize(this.Data)).ToObject<ObjectT>();
        }
    
        internal object GetData()
        {
            return Deserialize(this.Data);
        }
        internal static async Task<SqlBotDataEntity> GetSqlBotDataEntity(IAddress key, BotStoreType botStoreType, SqlBotDataContext context)
        {
            SqlBotDataEntity entity = null;
            var query = context.BotData.OrderByDescending(d => d.Timestamp);
            switch (botStoreType)
            {
                case BotStoreType.BotConversationData:
                    entity = await query.FirstOrDefaultAsync(d => d.BotStoreType == botStoreType
                                                    && d.ChannelId == key.ChannelId
                                                    && d.ConversationId == key.ConversationId);
                    break;
                case BotStoreType.BotUserData:
                    entity = await query.FirstOrDefaultAsync(d => d.BotStoreType == botStoreType
                                                    && d.ChannelId == key.ChannelId
                                                    && d.UserId == key.UserId);
                    break;
                case BotStoreType.BotPrivateConversationData:
                    entity = await query.FirstOrDefaultAsync(d => d.BotStoreType == botStoreType
                                                    && d.ChannelId == key.ChannelId
                                                    && d.ConversationId == key.ConversationId
                                                    && d.UserId == key.UserId);
                    break;
                default:
                    throw new ArgumentException("Unsupported bot store type!");
            }
    
            return entity;
        }
        #endregion
    }
