    abstract class ParseNode { ... }
    sealed class OrNode : ParseNode 
    { 
      public ParseNode Left { get; }
      public ParseNode Right { get; }
      ...
      // Or maybe IEnumerable<ParseNode> Children { get; }
      // is easier; both techniques have their strengths.
    }
    sealed class AndNode : ParseNode { ... }
    sealed class NotNode : ParseNode { ... }
    sealed class IdentifierNode : ParseNode { ... }
    sealed class TrueNode : ParseNode { ... }
    sealed class FalseNode : ParseNode { ... }
