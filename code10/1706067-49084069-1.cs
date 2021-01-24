      public abstract class Token
      {
        public string Name { get; protected set; }
      }
    
      public class VariableToken : Token
      {
        public VariableToken(string name) { Name = name; }
      }
    
      public class OperatorToken : Token
      {
        public OperatorToken(string name) { Name = name; }
      }
