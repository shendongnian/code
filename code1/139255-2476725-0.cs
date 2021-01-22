    [Serializable]
    class Person : ISerializable
    {
        #region ISerializable Members
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Perform Serialization here
        }
        #endregion
    }
