    Expression<Func<Category,bool>> predicate;
    if(categoryId == null) {
        predicate = c=>c.ParentId == null;
    } else {
        predicate = c=>c.ParentId == categoryId;
    }
    var subCategories = this.Repository.Categories
               .Where(predicate).ToList().Cast<ICategory>();
