    [JsonObject(MemberSerialization.OptIn)]
    public class ChangeMsg<T> : SdnMessage where T : IChangedStatusDTO
    {
        [JsonConstructor]
        public ChangeMsg(List<Tuple<T, ChangedStatus>> tuples)
        {
            ChangedDataList = tuples;
        }
    
        [JsonProperty("ChangedDataList")]
        public List<Tuple<T, ChangedStatus>> ChangedDataList { get; }
    }
