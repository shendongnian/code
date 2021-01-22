      [Serializable]
      public class CommonException : Exception
      {
        public CommonException() { }
        public CommonException(string message)
         : base(message) { }
        public CommonException(string message, Exception inner)
         : base(message, inner) { }
        protected CommonException(
        SerializationInfo info,
        StreamingContext context)
          : base(info, context)
        { }
    
        public override void GetObjectData(
        SerializationInfo info,
        StreamingContext context)
        {
          if (context.State == StreamingContextStates.CrossAppDomain)
            info.SetType(typeof(CommonException));
          base.GetObjectData(info, context);
        }
      }
