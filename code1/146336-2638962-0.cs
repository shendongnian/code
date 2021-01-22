            mockGet.Setup(mock => mock.Get(It.IsAny<Expression<Func<TEnterpriseObject, bool>>>())).Returns(
                (Expression<Func<TEnterpriseObject, bool>> expression) =>
                    {
                        var items = new List<TEnterpriseObject>();
                        var translator =
                            (IEntityTranslator<TEntity, TEnterpriseObject>)
                            ObjectFactory.GetInstance(typeof (IEntityTranslator<TEntity, TEnterpriseObject>));
                        fakeList.ForEach(fake => items.Add(translator.ToEnterpriseObject(fake)));
                        var filtered = items.AsQueryable().Where(expression);
                        var results = new List<TEntity>();
                        filtered.ToList().ForEach(item => results.Add(translator.ToEntity(item)));
                        return results.AsQueryable();
                    });
