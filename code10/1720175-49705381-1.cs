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
    
            public override string ToString()
            {
                return String.Format("{0}{1}{2}{3}{4}{5}{6}"
                    , Id.PadRight(15, ' ')
                    , ItemName.PadRight(30, ' ')
                    , StartingQty.ToString().PadLeft(10, ' ')
                    , QtyMinRestck.ToString().PadLeft(10, ' ')
                    , QtySold.ToString().PadLeft(10, ' ')
                    , QtyRStcked.ToString().PadLeft(10, ' ')
                    , UnitPrice.ToString("C", CultureInfo.CurrentCulture).PadLeft(10, ' '));
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
