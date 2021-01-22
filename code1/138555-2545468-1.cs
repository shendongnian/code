    public class CategoryMap : ClassMap<Category> 
    { 
        public CategoryMap() 
        { 
            Id(x => x.Id); 
            Map(x => x.Name); 
     
            References(x => x.ParentCategory)
                .Column("ParentCategoryId")    // Many-To-One : parent
                .Nullable() 
                .Not.LazyLoad(); 
     
            HasMany(x => x.SubCategories) 
               .Cascade.All().Inverse().KeyColumn("ParentCategoryId");   //One-To-Many : chidren
     
        } 
    } 
