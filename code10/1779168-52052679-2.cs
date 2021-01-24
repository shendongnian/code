    using (EF context = new EF())
    {
            var values = context.MainTable.Include("ReferedTable");
            var referedValues = values.ReferedTable.ToList();
    
            foreach (var value in referedValues)
            {
                values.ReferedTable.Remove(value);
            }
            context.SaveChanges();
    }
