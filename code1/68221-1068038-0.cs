        static void Main(string[] args)
        {
            Hashtable ht1 = new Hashtable(1);
            ht1.Add("name", "bob");
            Console.WriteLine(ToCompactString(ht1));
            Console.WriteLine();
            string str = "name:bob";
            Console.WriteLine(ToCompactString(str));
            Console.ReadLine();
        }
        private static string ToCompactString(object obj)
        {
            var ms = new MemoryStream();
            var ds = new DeflateStream(ms, CompressionMode.Compress);
            var bf = new BinaryFormatter();
            bf.Serialize(ds, obj);
            byte[] bytes = ms.ToArray();
            ds.Close();
            ms.Close();
            string result = Convert.ToBase64String(bytes);
            return result;
        }
