    public interface IParsingSocket {}
    public interface IGUISOcket {}
    public class InputSocket : BaseSocket, IParsingSocket, IGUISOcket  { }
    public class InternalSocket : BaseSocket, IParsingSocket  {}
    public class OutputSocket : BaseSocket, IGUISOcket {}
