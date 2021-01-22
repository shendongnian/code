     if (model != null && ModelState.IsValid)
                    {
                        var categoryCreate = new Categories
                        {
                            CategoryName = model.CategoryName.TrimStart().TrimEnd(),
                            Description = model.Description.TrimStart().TrimEnd()
                        };
                        _CategoriesService.Create(categoryCreate);
                    }
