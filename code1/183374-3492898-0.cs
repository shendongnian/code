    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
      ValueProviderResult valueProviderResult;
      int shareClassId = -1;
      if (bindingContext.ValueProvider.TryGetValue("shareClassId", out valueProviderResult))
      {
          shareClassId = valueProviderResult.ConvertTo(typeof(int));
      }
      ShareClassViewModel shareClassViewModel = ... // create Viewmodel instance
      shareClassViewModel.ShareClass = new ShareClass() { Id = shareClassId };
      
      return shareClassViewModel;
    }
