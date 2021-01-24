   
     public List<Like> GetLikesForUser(string facebookID)
                {
                    List<Like> likes = new List<Like>();
    
                    dynamic resultNode = _facebookClient.Get(facebookID + "?fields=likes{ name, created_time, category, category_list}");//likes?fields=likes
    
                    if (resultNode.likes != null)
                    {
                        dynamic result = resultNode.likes;
    
                        if (result.ToString().Contains("data"))
                        {
                            while (result != null)
                            {
                                if (result.ToString().Contains("data"))
                                {
                                    foreach (var item in result.data)
                                    {
                                        likes.Add(new Like
                                        {
                                            Name = item.name,
                                            ID = item.id,
                                            Category = item.category,
                                            Created_time = Convert.ToDateTime(item.created_time),
                                            Category_List = PopulateCategoryList(item.category_list)
    
                                        });
                                    }
    
                                }
                                var next = GetNextURL(result.ToString());
    
                                if (!string.IsNullOrEmpty(next))
                                {
                                    result = _facebookClient.Get(next);
                                }
                                else
                                {
                                    result = null;
                                }
                            }
                        }
                    }
                    return likes;
                }
    
     private List<Category> PopulateCategoryList(dynamic categories)
            {
                List<Category> categoryList = new List<Category>();
    
                if (categories != null)
                {
                    foreach (var item in categories)
                    {
                        Category category = new Category { ID = item.id, Name = item.name };
    
                        categoryList.Add(category);
                    }
                }
    
                return categoryList;
            }
