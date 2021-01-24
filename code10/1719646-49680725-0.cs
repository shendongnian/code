    // new interface to use
	public interface ICanSync
	{
		void Synchronize();
	}
	
	public abstract class TableBase
	{
		public virtual void TableName()
		{
			Console.WriteLine("I am Table: " + this.GetType().Name);
		}
	}
	
	public class TableA : TableBase
	{
	}
	
	public class TableB : TableBase
	{
	}
	
	public class TableC : TableBase
	{
	}
	
	public class Controller<T> : ICanSync where T : TableBase
	{
		
		private TableBase _t;
		
		public Controller(T table)
		{
			_t = table;
		}
		
		public void Synchronize()
		{
			_t.TableName();
		}
	}
