	public interface IWriter
	{
	    void Write(string message);
	}
	
	public interface IReader
	{
	    string Read();
	}
	
	public class MessageLog : IReader, IWriter
	{
	      public string Read()
	      {
	           // Implementation
	      }
	
	      public void IWriter.Write()
	      {
	           // Implementation
	      }
	}
	
	public class Foo
	{
		readonly MessageLog _messageLog;
		IWriter _messageWriter;
		
		public Foo
		{
			 _messageLog = new MessageLog();
			_messageWriter = (IWriter)_message;
		}
		
		public MessageLog Messages
		{
			get { return _messageLog; }
		}
	}
