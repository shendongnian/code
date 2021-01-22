        public static void GenericEventHandler(EventInfo info)
        {
            // do some logging here
        }
        public static void Bind(SourceOfManyEvents s)
        {
            foreach (var e in typeof(SourceOfManyEvents).GetEvents())
            {
                e.AddEventHandler(s, (Action<EventInfo>)GenericEventHandler);
            }
        }
