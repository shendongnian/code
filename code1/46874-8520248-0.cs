    public interface ISynchronized
	{
		object SyncRoot { get; }
	}
	public class SynchronizationCriticalClass : ISynchronized
	{
		public object SyncRoot
		{
			// you can return this, because this class wraps nothing.
			get { return this; }
		}
	}
	public class WrapperA : ISynchronized
	{
		ISynchronized subClass;
		public WrapperA(ISynchronized subClass)
		{
			this.subClass = subClass;
		}
		public object SyncRoot
		{
			// you should return SyncRoot of underlying class.
			get { return subClass.SyncRoot; }
		}
	}
	public class WrapperB : ISynchronized
	{
		ISynchronized subClass;
		public WrapperB(ISynchronized subClass)
		{
			this.subClass = subClass;
		}
		public object SyncRoot
		{
			// you should return SyncRoot of underlying class.
			get { return subClass.SyncRoot; }
		}
	}
	// Run
	class MainClass
	{
		delegate void DoSomethingAsyncDelegate(ISynchronized obj);
		public static void Main(string[] args)
		{
			SynchronizationCriticalClass rootClass = new SynchronizationCriticalClass();
			WrapperA wrapperA = new WrapperA(rootClass);
			WrapperB wrapperB = new WrapperB(rootClass);
			// Do some async work with them to test synchronization.
			//Works good.
			DoSomethingAsyncDelegate work = new DoSomethingAsyncDelegate(DoSomethingAsyncCorrectly);
			work.BeginInvoke(wrapperA, null, null);
			work.BeginInvoke(wrapperB, null, null);
			// Works wrong.
			work = new DoSomethingAsyncDelegate(DoSomethingAsyncIncorrectly);
			work.BeginInvoke(wrapperA, null, null);
			work.BeginInvoke(wrapperB, null, null);
		}
		static void DoSomethingAsyncCorrectly(ISynchronized obj)
		{
			lock (obj.SyncRoot)
			{
				// Do something with obj
			}
		}
		// This works wrong! obj is locked but not the underlaying object!
		static void DoSomethingAsyncIncorrectly(ISynchronized obj)
		{
			lock (obj)
			{
				// Do something with obj
			}
		}
	}
