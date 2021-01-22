    public T Get<T>(int id, string languageCode = Website.LanguageSettings.DefaultLanguageCode)
            {
                Entity<T> entity = _db<T>.FirstOrDefault(entity => entity.Id == id);
    
                if (languageCode.ToLower(CultureInfo.InvariantCulture) != Website.LanguageSettings.DefaultLanguageCode)
                {
                    using(IDocumentSession session = store.OpenSession())
                    {
                        Translation<T> translatedEntity = session.LuceneQuery<Translation<T>>(Website.RavenDbSettings.Indexes.Entities<T>)
                            .Where(string.Format("ObjectId:{0} AND LanguageCode:{1}", id, languageCode))
                            .OrderByDescending(entity=> entity.Id)
                            .FirstOrDefault();
    
                        T POCO = Mapper.DynamicMap<Translation<T>, T>(translatedEntity);
                        POCO.Id = entity.Id;
    
                        return POCO;
                    }
                }
    
                return Mapper.Map<Entities<T>, T>(Entity);
            }
