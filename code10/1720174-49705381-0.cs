    public class Inventory
    {
        public string Id { get; set; }
        public string ItemName { get; set; }
        public int StartingQty { get; set; }
        public int QtyMinRestck { get; set; }
        public int QtySold { get; set; }
        public int QtyRStcked { get; set; }
        public decimal UnitPrice { get; set; }
        public Inventory()
        {
        }
        public IEnumerable<Inventory> Load(string InventoryFileName)
        {
            var inventories = new List<Inventory>();
            using (var sr = new StreamReader(InventoryFileName))
            {
                sr.ReadLine(); //skip the first line
                while (!sr.EndOfStream)
                {
                    try
                    {
                        var fields = sr.ReadLine().Split(',');
                        inventories.Add(new Inventory
                        {
                            Id = fields[0]
                            ,
                            ItemName = fields[1]
                            ,
                            StartingQty = Int32.Parse(fields[2])
                            ,
                            QtyMinRestck = Int32.Parse(fields[3])
                            ,
                            QtySold = Int32.Parse(fields[4])
                            ,
                            QtyRStcked = Int32.Parse(fields[5])
                            ,
                            UnitPrice = Decimal.Parse(fields[6])
                        });
                    }
                    catch
                    {
                        //handle error here
                    }
                    
                }
            }
            
            return inventories;
        }
    }
