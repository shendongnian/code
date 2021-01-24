    using (var context = new ApplicationDbContext())
    {
        // read 
        var res = context.Recibo.Where(r => r.IdApartado == 7).ToList();
        // update
        foreach (r in res)
        {
            r.Estado = 3;
        }
        // save
        context.SaveChanges();
    }
