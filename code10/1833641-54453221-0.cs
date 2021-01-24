C#
private async void ThrottlingTest()
{
  SemaphoreSlim mutex = new SemaphoreSlim(30);
  Stopwatch sw = new Stopwatch();
  int numTasks = 150;
  Task[] tasks = new Task[numTasks];
  for (int i = 0; i < numTasks; i++)
    tasks[i] = TestAsync();
  sw.Start();
  await Task.WhenAll(tasks);
  sw.Stop();
  long duration = sw.ElapsedMilliseconds;
  async Task TestAsync()
  {
    await mutex.WaitAsync();
    try { await Task.Delay(5000); }
    finally { mutex.Release(); }
  }
}
  [1]: https://blog.stephencleary.com/2014/04/a-tour-of-task-part-0-overview.html
