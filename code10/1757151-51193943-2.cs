    ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
    SimpleIoc.Default.Register<CollectorViewModel>();
    Debug.Assert(SimpleIoc.Default.GetAllInstances<CollectorViewModel>().Count() == 1);
    var instance = ServiceLocator.Current.GetInstance<CollectorViewModel>("xyz");
    Debug.Assert(SimpleIoc.Default.GetAllInstances<CollectorViewModel>().Count() ==2);
    SimpleIoc.Default.Unregister<CollectorViewModel>("xyz");
    Debug.Assert(SimpleIoc.Default.GetAllInstances<CollectorViewModel>().Count() == 1);
