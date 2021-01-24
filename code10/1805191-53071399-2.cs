        public string ItemName { get; set; }
    }
    class Program
    {
        public static void GetComboCount()
        {
            var itemsCollection = new List<List<MyItem>>() {
                new List<MyItem>() { new MyItem() { ItemName = "Item1" } },
                new List<MyItem>() { new MyItem() { ItemName = "Item1" }, new MyItem() { ItemName = "Item2" } },
                new List<MyItem>() { new MyItem() { ItemName = "Item3" } },
                new List<MyItem>() { new MyItem() { ItemName = "Item1" }, new MyItem() { ItemName = "Item3" }, new MyItem() { ItemName = "Item2" } },
                new List<MyItem>() { new MyItem() { ItemName = "Item3" }, new MyItem() { ItemName = "Item1" } },
                new List<MyItem>() { new MyItem() { ItemName = "Item2" }, new MyItem() { ItemName = "Item1" } }
            };
            var comboCount = new Dictionary<string, int>();
            foreach (var row in itemsCollection)
            {
                var ids = row.Select(x => x.ItemName).OrderBy(x => x);
                var rowId = String.Join(",", ids);
                var rowIdCount = ids.Count();
                var seen = false;
                var comboCountList = comboCount.ToList();
                int currentRowCount = 1;
                foreach (var kvp in comboCountList)
                {
                    var key = kvp.Key;
                    if (key == rowId)
                    {
                        seen = true;
                        currentRowCount++;
                        continue;
                    }
                    var keySplit = key.Split(',');
                    var keyIdCount = keySplit.Length;
                    if (ids.Where(x => keySplit.Contains(x)).Count() == keyIdCount)
                    {
                        comboCount[kvp.Key] = kvp.Value + 1;
                    }
                    else if (keySplit.Where(x => ids.Contains(x)).Count() == rowIdCount)
                    {
                        currentRowCount++;
                    }
                }
                if (!seen)
                {
                    comboCount.Add(rowId, currentRowCount);
                }
                else
                {
                    comboCount[rowId] = currentRowCount;
                }
            }
            foreach (var kvp in comboCount)
            {
                Console.WriteLine(String.Format("{0}: {1}", kvp.Key, kvp.Value));
            }
        }
        static void Main(string[] args)
        {
            GetComboCount();
        }
    }
