    public class ItemGeneric<T> : Item
    {
        public T Data { get; set; }
        public override void DoStuff()
        {
            //do generic typed stuff here
            Console.WriteLine(Data);
        }
    }
