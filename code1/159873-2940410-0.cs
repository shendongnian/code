<span>
public class ThreadSafeList<T> : List<T>
{
	private List<T> list;
	// Use any normal List constructor here.
	public ThreadSafeList(List<T> list)
	{
		this.list = list;
	}
	public bool Add(T item)
	{
		lock (list)
		{
			return this.Add(item);
		}
	}
}
</span>
