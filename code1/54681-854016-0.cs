    public Presenter(IView view):this(view, new Dependency()){}
    
    public Presenter(IView view, IDependency dependency)
    {
        this.View = view;
        this.Dependency = dependency;
    }
