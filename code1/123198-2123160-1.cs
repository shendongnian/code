    public IEnumerable<BlogPost> FetchAllBlogs(int? CatId)
    {
      return from blogToCategories in BlogToCategory.All() 
             join blogPosts in BlogPost.All() on blogPosts.Id equals blogToCategories.BlogId 
             where blogToCategories.CategoryID == CatId
             select blogPosts;
    }
