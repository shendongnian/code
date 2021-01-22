     Datacontext db = new Datacontext(); // replace with your DataContext
     Product originalProduct = 
             db.Products.Single(p => p.Id == 2); // get product with Id 2
        
     originalProduct.Name = "SomeName";  // only reset Name prop
     originalProduct = p;                // or you may assign p to originalProduct
     db.SubmitChanges();                 // submit changes to DB
