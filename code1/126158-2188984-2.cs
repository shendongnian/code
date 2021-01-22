    using (new TransactionScope())
    {
        Manifest manifest = new Manifest
        {
            AllocatedTransactions.Add(new AllocatedTransaction
            {
                Quantity = 5
            }
        };
        DataContext.Manifests.InsertOnSubmit(manifest);
        DataContext.SubmitChanges();
        Manifest newManifest = DataContext.Manifests.Where(a => a.ID == manifest.ID).SingleOrDefault(); 
        Assert.AreEqual(manifest.AllocatedTransactions.First().Quantity, newManifest.AllocatedTransactions.First().Quantity);
    }
