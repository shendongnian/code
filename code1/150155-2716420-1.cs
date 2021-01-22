    [Serializable]
    public class ObservableCollection2<T>: ObservableCollection<T>, ISerializable
    {
        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            this.DateDeserialized = DateTime.Now;
        }
    }
