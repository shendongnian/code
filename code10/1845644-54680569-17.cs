    abstract class ParseNode { ... }
    sealed class OrNode : ParseNode 
    { 
      public ParseNode Left { get; }
      public ParseNode Right { get; }
      ...
    }
    sealed class AndNode : ParseNode { ... }
    sealed class NotNode : ParseNode { ... }
    sealed class IdentifierNode : ParseNode { ... }
    sealed class TrueNode : ParseNode { ... }
    sealed class FalseNode : ParseNode { ... }
