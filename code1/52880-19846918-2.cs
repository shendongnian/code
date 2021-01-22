     using (var ctx = new TestDBContext())
        {
            ctx.Items.Add(item);
            ctx.SaveChanges();
            throw new Exception() // Connections were closed, as expected.
        
         }
