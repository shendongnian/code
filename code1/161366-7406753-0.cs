    public enum EventType
        {
            NewVersion = 1,
            Accepted = 2,
            Rejected = 3,
            BruteForce = 4
        }
    
        public static class EventTypeExtension
        {
            public static string Display(this EventType type)
            {
                return Strings.ResourceManager.GetString("EventType_" + type);
            }
        }
