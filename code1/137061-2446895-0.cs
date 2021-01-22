    IDictionary<string, ValueProviderResult> contactValueProvider = bindingContext.ValueProvider
                .Select(t => new { t.Key, t.Value })
                .Where(t => t.Key.Contains("EventContact"))
                .ToDictionary(t => t.Key, t => t.Value);
    ModelBindingContext contactBindingContext = new ModelBindingContext()
            {
                ModelName = "EventContact",
                ModelState = bindingContext.ModelState,
                ModelType = typeof(List<EventContact>),
                PropertyFilter = bindingContext.PropertyFilter,
                ValueProvider = contactValueProvider
            };
    _event.Contacts = ModelBinders.Binders.DefaultBinder.BindModel(controllerContext, contactBindingContext) as IQueryable<EventContact>;
