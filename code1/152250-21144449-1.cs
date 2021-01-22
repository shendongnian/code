    public abstract class NodeBase
    {
        public abstract NodeBase GetNode();
    }
    public class SpecialNode : NodeBase
    {
        public override NodeBase GetNode()
        {
            return ThisStaticClass.MySpecialNode;
        }
    }
    public class OtherSpecialNode : NodeBase
    {
        public override NodeBase GetNode()
        {
            return ThisStaticClass.MyOtherSpecialNode;
        }
    }
    //and in your generic method, just:
    public static T GetNode<T>() where T : NodeBase, new()
    {
        return (T)new T().GetNode();
    }
