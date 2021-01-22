    [System.Serializable]
    public class ObjectPropertyChanged
    {
        public ObjectPropertyChanged(string objectId, string propertyName, string previousValue, string changedValue)
        {
            ObjectId = objectId;
            PropertyName = propertyName;
            PreviousValue = previousValue;
            ProposedChangedValue = changedValue;
        }
        public string ObjectId { get; set; }
        public string PropertyName { get; set; }
        public string PreviousValue { get; set; }
        public string ProposedChangedValue { get; set; }
    }
