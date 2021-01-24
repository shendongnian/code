    //Not possible with unity>=5.9.0, this way uc has access to class methods
    var uc = new UnityContainer();
    using(var child = uc.CreateChildContainer()){...}
    //Possible with unity>=5.9.0, this way uc has access to interface methods
    IUnityContainer uc = new UnityContainer();
    using(var child = uc.CreateChildContainer()){...}
