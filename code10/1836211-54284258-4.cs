    public struct EventDescriptor<T>
    {
        public Guid AggregateId;
        public T EventData;
        public long TimeStamp;
        public ChangeType EventType;
        public int Version;
    
        public EventDescriptor(Guid id, IEvent eventData)
        {
            AggregateId = id;
            var strEventData = JsonConvert.SerializeObject(eventData, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            EventData = MyGenericMethod(strEventData);
            Version = 1;
            TimeStamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
            EventType = (ChangeType)Enum.Parse(typeof(ChangeType), eventData.GetType().GetGenericArguments().First().Name);
        }
    
        public static T MyGenericMethod(string strEventData)
        {
            JObject jobject = JObject.Parse(strEventData);
            T result = jobject.SelectToken("ChangeSet").ToObject<T>();
            return result;
        }
    }
