      namespace CSLibrary
      {
        public class CSClass
        {
          public delegate string ACSharpDelegate (string message);
    
          public string Hello (string message)
          {
            return string.Format("Hello {0}", message);
          }
        }
      }
