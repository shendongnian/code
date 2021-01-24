    tousLesArticlesFromDb
                    .ToList()
                    .Where( *** )
                    .OrderBy(a => a.CreateDate)
                    .Take(criteriaModel.NbrItemsParPage)
                    .Select(
                        a => new ListeArticlesModel
                        {
                            Items = new List<TuileArticleModel>
                            {
                                // returns a TuileArticleModel 
                                getItem(a)
                            },
                        })
