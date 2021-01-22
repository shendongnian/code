    public class Category
        {
            public int Id { get; set; }
            public string  Name { get; set; }
            public int? ParentId { get; set; }
            public virtual Category Parent { get; set; }
            public virtual ICollection<Category> Children { get; set; }
            public byte[] Image { get; set; }
        }
    public class Product
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public Category ProductCategory { get; set; }
            public int ProductCategoryId { get; set; }
            public byte[] Image { get; set; }
        }
    public List<Category> GethierarchicalTree(int? parentId=null)
            {
                var allCats = new BaseRepository<Category>().GetAll();
    
                return allCats.Where(c => c.ParentId == parentId)
                                .Select(c => new Category()
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    ParentId = c.ParentId,
                                    Children = GetChildren(allCats.ToList(), c.Id)
                                })
                                .ToList();
            }
    
            public List<Category> GetChildren(List<Category> cats, int parentId)
            {
                return cats.Where(c => c.ParentId == parentId)
                        .Select(c => new Category
                        {
                            Id = c.Id,
                            Name = c.Name,
                            ParentId = c.ParentId,
                            Children = GetChildren(cats, c.Id)
                        })
                        .ToList();
            }
