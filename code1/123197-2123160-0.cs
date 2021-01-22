    public IEnumerable<BlogPost> FetchAllBlogs(int? CatId)
    {
      return from categories in CategoryLink.All()
             join blogToCategories in BlogToCategory.All() on categories.Id equals blogToCategories.CategoryId
             join blogPosts in BlogPost.All() on blogPosts.Id equals blogToCategories.BlogId 
             where categories.CategoryID == CatId
             select categories.BlogPost;
    }
