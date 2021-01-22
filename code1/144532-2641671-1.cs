[TestFixture]
public class GroupCacheTest
{
	private int _threadFinishedCount;
	private void MultiThreadTestWorker(object obj)
	{
		for (int n = 0; n &lt; 10; n++)
		{
			for (int m = 0; m &lt; 25; m++)
			{
				using (RowObject row 
					= GroupCache.GetGroupCache(n).GetCachedItem(m))
				{
					row.Property1 = string.Format("{0} {1} {2}", obj, n, m);
					Thread.Sleep(3);
				}
			}
		}
		Interlocked.Increment(ref _threadFinishedCount);
	}
	[Test]
	public void MultiThreadTest()
	{
		_threadFinishedCount = 1;
		for (int i = 0; i &lt; 20; i++)
		{
			ThreadPool.QueueUserWorkItem(MultiThreadTestWorker, "Test-" + i);
		}
		while (_threadFinishedCount &lt; 10)
			Thread.Sleep(100);
	}
}
