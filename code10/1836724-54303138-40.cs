    [Serializable]
    public class EventDelayPair
    {
        public UnityEvent unityEvent;
        public float Delay;
        // add a time multiplicator for each delay with default 1
        public float TimeMultiplicator = 1.0f;
    }
