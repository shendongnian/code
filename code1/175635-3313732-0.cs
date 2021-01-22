static void Main(string[] args)
{
    {
        new Dictionary<int,int>(10000000);
    }
    while (true)
    {
        System.Threading.Thread.Sleep(1000);
    }
}
