    var q = from p in Context.Product
            select new ProductPresentation
            {
               Id = p.Id,
               // etc.
               Description = new ProductDescriptionPresentation
               {
                   Language = (from l in p.ProductDescription.Languages
                               where l.AlternateCode.Equals("es", StringComparison.OrdinalIgnoreCase)
                               select l).FirstOrDefault(),
                   // etc.
               }
            };
