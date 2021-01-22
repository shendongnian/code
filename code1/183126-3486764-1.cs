    namespace MessageProcessor
    {
       partial interface IMessageVisitor
       {
          void Visit (SimpleMessage message);
          void Visit (ComplexMessage message);
          void Visit (OtherMessage message);
       }
       abstract partial class Message
       {      
          public abstract void Accept (IMessageVisitor visitor);
       }
       sealed partial class SimpleMessage : Message
       {      
          public override void Accept (IMessageVisitor visitor)
          {
             visitor.Visit (this);
          }
       }
       sealed partial class ComplexMessage : Message
       {      
          public override void Accept (IMessageVisitor visitor)
          {
             visitor.Visit (this);
          }
       }
       sealed partial class OtherMessage : Message
       {      
          public override void Accept (IMessageVisitor visitor)
          {
             visitor.Visit (this);
          }
       }
    }
