<br/>Add database read after the comment// Add code to read from database...
public class GroupCache : SimpleCache&lt;RowObject, int>
{
	private static readonly object GroupCacheObjectLock = new object();
	public GroupCache(int groupId)
	{
		GroupId = groupId;
	}
	public int GroupId { get; private set; }
	public static GroupCache GetGroupCache(int groupId)
	{
		lock (GroupCacheObjectLock)
		{
			if (HttpContext.Current.Cache["Group-" + groupId] == null)
			{
				HttpContext.Current.Cache["Group-" + groupId] 
					= new GroupCache(groupId);
			}
		}
		return HttpContext.Current.Cache["Group-" + groupId];
	}
	public override RowObject CreateItem(int id, 
			SimpleCache&lt;RowObject, int> cache)
	{
		return new RowObject(id, GroupId, this);
	}
}
public class RowObject : SimpleCacheItem&lt;RowObject, int>
{
	private string _property1;
	public RowObject(int rowId, int groupId, SimpleCache&lt;RowObject, int> cache)
		: base(rowId, cache)
	{
		// Add code to read from database...
	}
	public string Property1
	{
		get { return _property1; }
		set
		{
			if (!AcquireLock(-1)) return;
			_property1 = value;
#if DEBUG
			Trace.WriteLine(string.Format("Thread id: {0}, value = {1}", 
				Thread.CurrentThread.ManagedThreadId, value));
#endif
		}
	}
}
