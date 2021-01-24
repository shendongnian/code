    public async Task UpdateAndRefreshContractMetaDataCollection(ObservableCollection<Category> Categories)
    {
        Type type = typeof(Category);
        var updatedCategories = await GetLatestUpdatedCategories();
        var CatDict = Categories.ToDictionary(c => c.ID);
        if (updatedCategories.Count != 0)
        {
            try
            {
                int i = 0;
                foreach (var category in updatedCategories)
                {
                    var categoryCopy = CatDict.ContainsKey(category.ID) ? CatDict[category.ID] : null;
                    if (categoryCopy != null)
                    {
                        i += 1;
                        if (!compareLogic.Compare(categoryCopy, category).AreEqual)
                        {
                            mapper.Map<Category, Category>(category, categoryCopy);
                        }
                        else
                        {
                            Categories.Add(category);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error updating categories", e.Message);
            }
        }
    }
