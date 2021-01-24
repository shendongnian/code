    public interface IMessageBoxWrapper 
    {
         MessageBoxResult Show(string message);
    }
    public class MessageBoxWrapper : IMessageBoxWrapper
    {
        public MessageBoxResult Show(string message)
        { 
            return MessageBox.Show(message);
        }
     }
     public class SomeClass 
     {
     
          private readonly IMessageBoxWrapper _messageBox;
          public SomeClass(IMessageBoxWrapper messageBox)
          {
              _messageBox = messageBox;
          }
          
          public void SomeFunction()
          {              
              MessageBoxResult mResult= _messageBox.Show("Displaying message");
              bool result;
              if(mResult == MessageBoxResult.OK)
              {
                result = AnyFunction();
              }
              return result;
          } 
     }
     
