    public interface IMessageVisitor
    {
        void VisitSimple(SimpleMessage msg);
        void VisitComplex(ComplexMessage msg);
    }
    public abstract class Message
    {
        public abstract void Accept(IMessageVisitor visitor);
    }
    public class SimpleMessage : Message
    {
        public override void Accept(IMessageVisitor visitor)
        {
            visitor.VisitSimple(this);
        }
    }
    public class ComplexMessage : Message
    {
        public override void Accept(IMessageVisitor visitor)
        {
            visitor.VisitComplex(this);
        }
    }
    public class MessageProcessor : IMessageVisitor
    {
        void IMessageVisitor.VisitSimple(SimpleMessage msg)
        { process simple message }
        void IMessageVisitor.VisitComplex(ComplexMessage msg)
        { process complex message }
        public void Process(Message msg)
        {
            msg.Accept(this);
        }
    }
