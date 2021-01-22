    [Serializable]
    public class Item
    {
        public string Data { get; set; }
    }
    [Serializable]
    public class ItemHolder
    {
        public Item Item1 { get; set; }
        public Item Item2 { get; set; }
    }
    public class Program
    {
        public static void Main(params string[] args)
        {
            {
                Item item0 = new Item() { Data = "0000000000" };
                ItemHolder holderOneInstance = new ItemHolder() { Item1 = item0, Item2 = item0 };
                var fs0 = File.Create("temp-file0.txt");
                var formatter0 = new BinaryFormatter();
                formatter0.Serialize(fs0, holderOneInstance);
                fs0.Close();
                Console.WriteLine("One instance: " + new FileInfo(fs0.Name).Length); // 335
                //File.Delete(fs0.Name);
            }
            {
                Item item1 = new Item() { Data = "1111111111" };
                Item item2 = new Item() { Data = "2222222222" };
                ItemHolder holderTwoInstances = new ItemHolder() { Item1 = item1, Item2 = item2 };
                var fs1 = File.Create("temp-file1.txt");
                var formatter1 = new BinaryFormatter();
                formatter1.Serialize(fs1, holderTwoInstances);
                fs1.Close();
                Console.WriteLine("Two instances: " + new FileInfo(fs1.Name).Length); // 360
                //File.Delete(fs1.Name);
            }
        }
    }
