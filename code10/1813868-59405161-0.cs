public static void Retry(Action test, int retry = 10, int sleep = 0, [CallerMemberName] string testName = null)
{
    int current = 1;
    retry = Math.Max(1, Math.Min(retry, 10));
    while (current <= retry)
    {
        try
        {
            test();
            break;
        }
        catch (Exception ex) when (current < retry)
        {
            Debug.WriteLine("Test {0} failed ({1}. try): {2}", testName, current, ex);
        }
        if (sleep > 0)
        {
            Thread.Sleep(sleep);
        }
        current++;
    }
}
usage
[TestMethod]
public void CanRollbackTransaction()
{
    Helpers.Retry(() =>
    {
        var even = DateTime.Now.Second % 2 == 0;
        Assert.IsTrue(even);
    }, 3, 1000);
}
