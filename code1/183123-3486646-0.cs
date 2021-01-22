    public interface IMessageVisitor
    {
        void VisitSimple(SimpleMessage msg);
        void VisitComplex(ComplexMessage msg);
    }
    public class Message
    {
        public abstract void Accept(IMessageVisitor visitor);
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
