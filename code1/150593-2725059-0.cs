    public class Node
    {
        //Node stuff here...
    }
    public struct NodeToken
    {
        //I've simplified this
        //This should be an internal read-only property
        internal int TokenId;
        internal NodeToken(int tokenId) { TokenId = tokenId; }
    }
    public class Branch
    {
        //Set in constructor, most likely...
        private INodeOperations _operations;
        // Contains references to Nodes
        public NodeToken NodeA;
        public NodeToken NodeB;
    }
    public interface INodeOperations
    {
        //Various things you can do with Nodes
    }
    public class Graph : INodeOperations
    {
        private int _tokenStart;
        private Dictionary<int, Node> Nodes;
        private List<Branch> Branches;
        //The Graph will create actual Nodes, but only ever hand out tokens
        //All operations on Nodes are through these tokens
        //The Nodes dictionary is a mapping from TokenId -> Node
        //If a TokenId is not in the Keys list, the node is no longer valid
        //At that point, you can throw an exception indicating the consumer has a stale reference
    }
