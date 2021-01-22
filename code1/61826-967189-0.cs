    public class TblPartCount
    {
        public int InventoryCountID { get; set; }
        public int? ActionID { get; set; }
        public string PartNumber { get; set; }
        public int RevLevel { get; set; }
        public string SAPLocation { get; set; }
        public int Quantity { get; set; }
    }
    private static void ConditionalGroupBy()
        {
            bool pCheck = true;
            var lList = new List<TblPartCount>
                            {
                                new TblPartCount { InventoryCountID = 1, ActionID = 2, PartNumber = "123", RevLevel = 1, SAPLocation = "AAAA", Quantity = 100 },
                                new TblPartCount { InventoryCountID = 1, ActionID = 2, PartNumber = "123", RevLevel = 1, SAPLocation = "BBBB", Quantity = 200 }
                            };
            var lOutput = lList
                              .Where(pArg => pArg.InventoryCountID == 1)
                              .Where(pArg => pArg.ActionID != null)
                              .GroupBy(pArg => new
                              {
                                  PartNumber = pArg.PartNumber,
                                  RevLevel = pCheck ? pArg.RevLevel : 0,
                                  SAPLocation = pCheck ? pArg.SAPLocation : String.Empty
                              })
                              .Select(pArg =>
                                        new
                                        {
                                            PartNumber = pArg.Key.PartNumber,
                                            RevLevel = pArg.Key.RevLevel,
                                            SAPLocation = pArg.Key.SAPLocation,
                                            Qtry = pArg.Sum(pArg1 => pArg1.Quantity)
                                        });
            foreach (var lItem in lOutput)
            {
                Console.WriteLine(lItem);
            }
        }
