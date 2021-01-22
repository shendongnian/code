    <#@ template language="C#" #>
    <#
       // On VS2008 change C# above to C#v3.5
    
       // -----------------------------------------------------
       // Here we declare our different message types
       var messageTypes = new []
          {
             "Simple",
             "Complex",
             "Other",
          };
       // -----------------------------------------------------
    #>
    
    namespace MessageProcessor
    {
       partial interface IMessageVisitor
       {
    <#
       // Let's generate all message visitor methods
       foreach (var messageType in messageTypes)
       {
    #>
          void Visit (<#=messageType#>Message message);
    <#
       }
    #>
       }
       abstract partial class Message
       {      
          public abstract void Accept (IMessageVisitor visitor);
       }
    <#
       // Let's generate all message types
       foreach (var messageType in messageTypes)
       {
    #>
       sealed partial class <#=messageType#>Message : Message
       {      
          public override void Accept (IMessageVisitor visitor)
          {
             visitor.Visit (this);
          }
       }
    <#
       }
    #>
    }
