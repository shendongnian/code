Stopwatch watch = Stopwatch.StartNew();
using (Storage&lt;double&gt; helper = new Storage&lt;double&gt;("Storage.bin"))
{
    Console.WriteLine("Initialization Time: {0}", watch.ElapsedMilliseconds);
    string item;
    long index;
    Console.Write("Item to show: ");
    while (!string.IsNullOrWhiteSpace((item = Console.ReadLine())))
    {
        if (long.TryParse(item, out index) && index &gt;= 0 && index &lt; helper.Length)
        {
            watch.Reset();
            watch.Start();
            double value = helper[index];
            Console.WriteLine("Access Time: {0}", watch.ElapsedMilliseconds);
            Console.WriteLine("Item: {0}", value);
        }
        else
        {
            Console.Write("Invalid index");
        }
        Console.Write("Item to show: ");
    }
}
