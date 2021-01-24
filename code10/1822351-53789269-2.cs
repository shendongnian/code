    var map = viewModel.ToObjectDictionary();
    viewModel.GetType().GetProperties()
        .Where(x => x.HasAttribute<HiddenInputAttribute>())
        .Each(x => map.Remove(x.Name)); //remove all props with [HiddenInput]
    viewModel = map.FromObjectDictionary<ViewModel>(); //new viewModel without removed props
