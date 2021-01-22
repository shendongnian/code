    interface ItemProcessor
    {
        void ProcessItem(string s);
    };
    class MyItemProcessor : ItemProcessor
    {
        public void ProcessItem(string s)
        {
            Console.WriteLine(s);
        }
    };
    static void ProcessItems(ItemProcessor processor)
    {
        processor.ProcessItem("apple");
        processor.ProcessItem("orange");
        processor.ProcessItem("pear");
    }
    ProcessItems(new MyItemProcessor());
