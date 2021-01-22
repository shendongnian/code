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
	          return "";
	      }
	
	      void IWriter.Write(string message)
	      {
	           // Implementation
	      }
	}
	
	public class Foo
	{
		readonly MessageLog _messageLog;
		IWriter _messageWriter;
		
		public Foo()
		{
			 _messageLog = new MessageLog();
             _messageWriter = _messageLog;
		}
		
		public IReader Messages
		{
			get { return _messageLog; }
		}
	}
