     var q = from p in rangeConnection.RangeActivities
                join r in rangeConnection.RoundFires
                   on p.RangeActivityID equals r.RangeActivityID into sr
                from x in sr.DefaultIfEmpty()
                 select new
                            {
                                TestName = p.TestName,
                                DateTime = p.ActivityDateTime,
                                Notes = p.Notes,
                                RoundSerialNumber = x.RoundSerialNumber,
                                RoundType = x.RoundType,
                                LotStockNumber = x.LotNumber
                                //consider checking for string.IsNullOrEmpty() 
                                //for the RoundFires properties
                            };
 
