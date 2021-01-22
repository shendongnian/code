    namespace Messages
    {
        private enum AllMessageTypes
        {
            Update,
            Delete,
            Destroy,
            AddGraphic 
        }
        public static class Generic
        {
            public Int32 Update 
            {
                get { return (Int32)AllMessageTypes.Update; }
            }
            ...
        }
        public static class Graphics
        {
            public Int32 AddGraphic 
            {
                get { return (Int32)AllMessageTypes.AddGraphic ; }
            }
        }
    }
