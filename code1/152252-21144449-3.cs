    public abstract class NodeBase<T> where T : NodeBase<T>
    {
        public abstract T GetNode();
    }
    public class SpecialNode : NodeBase<SpecialNode>
    {
        public override SpecialNode GetNode()
        {
            return ThisStaticClass.MySpecialNode;
        }
    }
    public class OtherSpecialNode : NodeBase<OtherSpecialNode>
    {
        public override OtherSpecialNode GetNode()
        {
            return ThisStaticClass.MyOtherSpecialNode;
        }
    }
    //avoids cast
    public static T GetNode<T>() where T : NodeBase<T>, new()
    {
        return new T().GetNode();
    }
