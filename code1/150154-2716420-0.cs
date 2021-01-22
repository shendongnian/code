    [Serializable]
    public class ObservableCollection2<T>: ObservableCollection<T>, ISerializable
    {
        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext streamingContext)
        {
            // Do your thing here
        }
    }
