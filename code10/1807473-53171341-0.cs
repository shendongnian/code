     public static IEntity<T> ToModel<T>(this IEntityViewModel<T> viewModel)
        {
            return (IEntity<T>)Mapper.Map(viewModel, viewModel.GetType(), typeof(IEntity<T>));
        }
        public static IEntityViewModel<T> ToViewModel<T>(this IEntity<T> entity)
        {
            return (IEntityViewModel<T>)Mapper.Map(entity, entity.GetType(), typeof(IEntityViewModel<T>));
        }
