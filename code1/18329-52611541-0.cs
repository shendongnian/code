    ProductModelEdit model = new ProductModelEdit() ;
    //Init ModelState
    var modelBinder = new ModelBindingContext()
    {
        ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(
                          () => model, model.GetType()),
        ValueProvider=new NameValueCollectionValueProvider(
                            new NameValueCollection(), CultureInfo.InvariantCulture)
    };
    var binder=new DefaultModelBinder().BindModel(
                     new ControllerContext(),modelBinder );
    ProductController.ModelState.Clear();
    ProductController.ModelState.Merge(modelBinder.ModelState);
    ViewResult result = (ViewResult)ProductController.CreateProduct(null,model);
    Assert.IsTrue(!result.ViewData.ModelState.IsValid);
    //Make sure Name has correct errors
    Assert.IsTrue(result.ViewData.ModelState["Name"].Errors.Count > 0);
    Assert.AreEqual(result.ViewData.ModelState["Name"].Errors[0].ErrorMessage, "Required");
    //Make sure Description has correct errors
    Assert.IsTrue(result.ViewData.ModelState["Description"].Errors.Count > 0);
    Assert.AreEqual(result.ViewData.ModelState["Description"].Errors[0].ErrorMessage, "Required");
