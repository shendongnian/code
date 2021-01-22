    namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DaContract Impl = new Impl();
            Impl.AddFriend(new Friend("Someone", "100"));
            Impl.AddFriend(new Friend("Someone else"));
            Console.ReadLine();
        }
    }
