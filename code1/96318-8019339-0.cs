    //this is a entity framework objects
    CTSPEntities CEntity = new CTSPEntities();
    //and this is ur example query
    var query = (from details in CEntity.Purchase_Product_Details<br/>
                             group details by new { details.Product_Details.Product_Code, details.Product_Details.Product_Name} into Prod
                             select new
                             {
                                 PID = Prod.Key.Product_Code,
                                 PName = Prod.Key.Product_Name,
                                 Amount = Prod.Sum(c => c.Lot_Amount),
                                 count= Prod.Count()
                             }).OrderBy(x => x.Amount);
                foreach (var item in query)
                {
                    Console.WriteLine("{0},{1},{2},{3}",item.PID,item.PName,item.Amount,item.count);
                }
                Console.ReadLine();
