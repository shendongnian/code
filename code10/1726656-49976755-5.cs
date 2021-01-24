protected List< Action< IVenturaRepository, ViewModel>> SetForeignKeyProperties()
        {
            var viewModelType = typeof(ViewModel);
            var foreignKeyProperties = viewModelType.GetProperties().Where(x => x.PropertyType.IsSubclassOf(typeof(BaseViewModel)));
            var actions = new List< Action< IVenturaRepository, ViewModel>>();
            var repositoryType = typeof(IVenturaRepository);
            foreach (var ForeignKeyProperty in foreignKeyProperties)
            {
                var foreignKeyIdProperty = viewModelType.GetProperties().SingleOrDefault(x => x.Name == ForeignKeyProperty.Name + "Id");
                //ForeignKeyProperty.SetValue(model, repository.GetList< OtherViewModel>().Single(x => x.Id == model.Id));
                var listMethod = repositoryType.GetMethods().SingleOrDefault(x => x.Name == "GetList").MakeGenericMethod(ForeignKeyProperty.PropertyType);
                var repositoryVariable = Expression.Parameter(repositoryType, "repository");
                var paramViewModelType = Expression.Parameter(viewModelType, "model");
                var paramForeignEntityId = Expression.Property(paramViewModelType, "Id");
                var listMethodCall = Expression.Call(repositoryVariable, listMethod);
                var foreignKeyTypeConstant = Expression.Constant(ForeignKeyProperty.PropertyType);
                var objectType = Expression.Parameter(typeof(object), "model");
                var modelParameter = Expression.Parameter(typeof(object), "x");
                var expressionForeignKeyId = Expression.Property(paramViewModelType, foreignKeyIdProperty.Name);
                var expressionForeignEntityId = Expression.Convert(Expression.Property(Expression.Convert(modelParameter, ForeignKeyProperty.PropertyType), "Id"), foreignKeyIdProperty.PropertyType);
                var condition =
                    Expression.Lambda<Func<object, bool>>(
                        Expression.Equal(
                            expressionForeignKeyId,
                            expressionForeignEntityId
                        ),
                        modelParameter
                    );
                var singleMethodCall = Expression.Call(typeof(Enumerable), "SingleOrDefault", new[] { ForeignKeyProperty.PropertyType }, listMethodCall, condition);
                //var singleMethodCall = Expression.Call(listMethodCall, singleMethod, condition);
                var setMethod = ForeignKeyProperty.GetSetMethod();
                //var oParameter = Expression.Parameter(viewModelType, "obj");
                var vParameter = Expression.Parameter(typeof(ViewModel), "value");
                var method = Expression.Call(paramViewModelType, setMethod, singleMethodCall);
                var lamdaParameterExpressions = new[]
                {
                    repositoryVariable,
                    paramViewModelType
                };
                var expression = Expression.Lambda<Action<IVenturaRepository, ViewModel>>(method, lamdaParameterExpressions);
                actions.Add(expression.Compile());
            }
            return actions;
        }
