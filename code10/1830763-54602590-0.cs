C#
static int DoSomeWork(int Item, int time)
{
  Console.Write($"    Working.on item {Item}..");
  Thread.Sleep(time);
  Console.WriteLine($"done.");
  return Item;
}
You can parallelize it as such:
C#
static List<int> ThreadIt(int threads, int numItems)
{
  Console.WriteLine($"Item limit: {numItems}, threads: {threads}");
  var items = Enumerable.Range(0, numItems);
  return items.AsParallel().WithDegreeOfParallelism(threads)
      .Select(i => DoSomeWork(i, 500))
      .ToList();
}
