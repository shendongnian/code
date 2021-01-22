    class DelegateSerializationSurrogate : ISerializationSurrogate {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context) {
            // do nothing
        }
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context) {
            // do nothing
            return null;
        }
    }
