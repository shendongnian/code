    ModelViewModel CreateModelViewModel(IModel model)
    {
        Type viewModelType = typeof(ModelViewModel<>).MakeGenericType(model.Type);
        ModelViewModel viewModel = Activator.CreateInstance(viewModelType, model);
        return viewModel;
    }
