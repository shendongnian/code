    class StrongRef<ObjectType>
    {
        public StrongRef(ObjectType actualObject)
        {
            this.actualObject = actualObject;
        }
        public ObjectType ActualObject
        {
            get { return this.actualObject; }
            set { this.actualObject = value; }
        }
        private ObjectType actualObject;
    }
