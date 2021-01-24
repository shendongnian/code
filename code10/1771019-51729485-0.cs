    public Cuisine GetCuisines(string cuisine)
    {
        using (ResturantContext context = new ResturantContext())
        {
            // db.Cuisines.Where(x => x.Name.Contains(Cuisine))
            return (from m in context.Cuisines
                       .Include("Images")
                       .Include("Category")
                    where m.Name == cuisine
                    select m).FirstOrDefault();
        }
    }
