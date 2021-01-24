    var productCategories = context.Where(<my filter>)
                   .OrderBy(x => x.SortOrder)
                   .Select(x => new ViewModelProductCategory()
                     {
                        Id = x.Id,
                        Title = x.Title,
                        SortOrder = x.SortOrder, 
                        ParentId = x.ParentId
                     }); 
    
    var viewModelProductCategories  = new ViewModelProductCategories()
                    {
                       Categories  = productCategories 
                       ...
                       // other shenanigans here  
                    };
            
