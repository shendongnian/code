      [global::System.Serializable]
      public class CommonException : Exception
      {
        public CommonException() { }
        public CommonException(string message) : base(message) { }
        public CommonException(string message, Exception inner) : base(message, inner) { }
        protected CommonException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
          : base(info, context)
        {
    
        }
    
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
          info.SetType(typeof(CommonException));
          base.GetObjectData(info, context);
        }
      }
