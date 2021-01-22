        using (var desDb = new DesDbContext())
        {
            // del-table-all --------------------------------------------------------
            desDb.Database.ExecuteSqlCommand("DELETE FROM [Products]");
            
            foreach (var desItem in desList) //desList is List of Product
            {
                // reseed identity key
                desDb.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Products', RESEED," 
                    + (desItem.ProductID - 1) + ");");
                // and record
                desDb.Products.Add(desItem);                        
                // save-db                    
                desDb.SaveChanges();
            }
        }
