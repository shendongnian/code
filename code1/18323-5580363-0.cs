    //[Required]
    //public string Name { get; set; }
    //[Required]
    //public string Description { get; set; }
    ProductModelEdit model = new ProductModelEdit() ;
    //Init ModelState
    var modelBinder = new ModelBindingContext()
    {
        ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, model.GetType()),
        ValueProvider=new NameValueCollectionValueProvider(new NameValueCollection(),CultureInfo.InvariantCulture)
    };
    var binder=new DefaultModelBinder().BindModel(new ControllerContext(),modelBinder );
    ProductController.ModelState.Clear();
    ProductController.ModelState.Merge(modelBinder.ModelState);
    ViewResult result = (ViewResult)ProductController.CreateProduct(null,model);
    Assert.IsTrue(result.ViewData.ModelState["Name"].Errors.Count > 0);
    Assert.True(result.ViewData.ModelState["Description"].Errors.Count > 0);
    Assert.True(!result.ViewData.ModelState.IsValid);
