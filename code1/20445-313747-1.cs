    public sealed class SomeMessage
    {
      public string Name { get; private set; }
      public int Age { get; private set; }
      // Can only be called in this class and nested types
      private SomeMessage() {}
    
      public sealed class Builder
      {
        private SomeMessage message = new SomeMessage();
        
        public string Name
        {
          get { return message.Name; }
          set { message.Name = value; }
        }
        public int Age
        {
          get { return message.Age; }
          set { message.Age = value; }
        }
        public SomeMessage Build()
        {
          // Check for optional fields etc here
          SomeMessage ret = message;
          message = null; // Builder is invalid after this
          return ret;
        }
      }
    }
