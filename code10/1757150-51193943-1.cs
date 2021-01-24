    ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
    SimpleIoc.Default.Register<CollectorViewModel>();
    Debug.Assert(SimpleIoc.Default.GetAllInstances<CollectorViewModel>().Count() == 1);
    SimpleIoc.Default.Unregister<CollectorViewModel>();
    Debug.Assert(SimpleIoc.Default.GetAllInstances<CollectorViewModel>().Count() == 0);
