    DetachedCriteria features = DetachedCriteria.For<FeatureValue>();
                    features.SetProjection(Projections.Property("Id"));
                    features.Add(Property.ForName("Id").EqProperty("value.Id"));
                    var and = new Conjunction();
                    foreach (var l in FeatureIdCollection)
                        and.Add(Expression.Eq("Id", l));
                    features.Add(and);
                    query
                        .CreateCriteria("EstateFeatures")
                        .CreateCriteria("MyFeatureValue","value")
                        .Add(Subqueries.Exists(features));
