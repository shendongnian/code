    var lstCategory = new List<Category> { new Category { Id=1}, new Category {Id=2 }, new Category { Id = 3 } };
    var lstRecipe = new List<Recipe> { new Recipe { Id=1,Name="C1",CatId=1}, new Recipe { Id = 2, Name = "C2", CatId = 2 },
            new Recipe { Id =3, Name = "C3", CatId = 2 },new Recipe { Id =3, Name = "C4", CatId = 3 },new Recipe { Id=1,Name="C5",CatId=1} };
    var result = (from c in lstRecipe
                     join s in lstCategory
                     on c.CatId equals s.Id
                     group c by c.CatId
                     into g
                     let o = g.Take(10)
                     select o);
    var lstItems = new List<DtoModel>();
        foreach(var r in result)
        {
            var item = new DtoModel { Recipet = new List<RecipetDto>() };
            item.CategoryName = r.First().CatId.ToString();
            foreach(var s in r)
            {
                item.Recipet.Add(new RecipetDto
                {
                    Id=s.Id,
                    Name=s.Name
                });
            }
            lstItems.Add(item);
        }
