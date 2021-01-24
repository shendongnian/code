    var db = IronLeveldbBuilder.BuildFromPath(@"C:\test\leveldb");
            IEnumerable<IByteArrayKeyValuePair> data = db.SeekFirst();
            foreach (IByteArrayKeyValuePair pair in data)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"****{Encoding.Default.GetString(pair.Key.ToArray(), 0, pair.Key.Length)}****");
                Console.ResetColor();
                Console.WriteLine(Encoding.Default.GetString(pair.Value.ToArray(), 0, pair.Value.Length));
            }
